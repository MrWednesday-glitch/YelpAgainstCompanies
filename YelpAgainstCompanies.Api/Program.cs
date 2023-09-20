using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

//https://www.tektutorialshub.com/asp-net-core/asp-net-core-identity-tutorial/#create-new-aspnet-core-project
namespace YelpAgainstCompanies.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            var webAppBuilder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            webAppBuilder.Services.AddControllers();

            webAppBuilder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configBuilder.GetConnectionString("DefaultConnection"));
            }, ServiceLifetime.Singleton);
            webAppBuilder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
            }).AddEntityFrameworkStores<DataContext>(); //Is this last bit needed?
            webAppBuilder.Services.AddScoped<DataStore>();
            webAppBuilder.Services.AddScoped<Transformations>();
            webAppBuilder.Services.AddScoped<ICompanyService, CompanyService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            webAppBuilder.Services.AddEndpointsApiExplorer();
            webAppBuilder.Services.AddSwaggerGen();

            webAppBuilder.Services.AddCors(o => o.AddPolicy("myAllowSpecificOrigins", b =>
            {
                b.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader();
            }));

            var app = webAppBuilder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("myAllowSpecificOrigins");

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}