using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace YelpAgainstCompanies.Data;

public class DataContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public DataContext()
    {
        
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Company> Companies { get; set; } = null!;

    public DbSet<Rating> Rating { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(configBuilder.GetConnectionString("DefaultConnection"));
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //TODO Fill in the seed data
        base.OnModelCreating(builder);
    }
}
