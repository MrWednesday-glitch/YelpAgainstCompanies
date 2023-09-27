//https://www.tektutorialshub.com/asp-net-core/asp-net-core-identity-tutorial/#create-new-aspnet-core-project

namespace YelpAgainstCompanies.Api;

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
        webAppBuilder.Services.AddScoped<DataStore>(); //TODO Delete this once the database is up and running
        webAppBuilder.Services.AddScoped<Transformations>();
        webAppBuilder.Services.AddScoped<ICompanyService, CompanyService>();
        webAppBuilder.Services.AddScoped<IJwtAuthorityManager, JwtAuthorityManager>(); //TODO Write these

        webAppBuilder.Services.AddIdentity<AppUser, AppUserRole>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
        }).AddRoles<AppUserRole>()
            .AddEntityFrameworkStores<DataContext>();

        var jwtTokenConfiguration = configBuilder.GetSection("jwtTokenConfig")
            .Get<JwtTokenConfiguration>();
        webAppBuilder.Services.AddSingleton(jwtTokenConfiguration);

        webAppBuilder.Services.Configure<IdentityOptions>(options =>
        {
            options.SignIn.RequireConfirmedEmail = false;
        });

        webAppBuilder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(bearerOptions =>
            {
                bearerOptions.RequireHttpsMetadata = true;
                bearerOptions.SaveToken = false;
                bearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtTokenConfiguration.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfiguration.Secret)),
                    ValidateAudience = true,
                    ValidAudience = jwtTokenConfiguration.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });

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
        using var scope = app.Services.CreateScope();
        scope.ServiceProvider.GetRequiredService<DataContext>()
            .Database.Migrate(); //Migrate database when API runs

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