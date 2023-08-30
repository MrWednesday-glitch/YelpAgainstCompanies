
using YelpAgainstCompanies.Business.Services;
using YelpAgainstCompanies.Data;
using YelpAgainstCompanies.Domain.Interfaces;

namespace YelpAgainstCompanies.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webAppBuilder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            webAppBuilder.Services.AddControllers();

            webAppBuilder.Services.AddScoped<DataStore>();
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}