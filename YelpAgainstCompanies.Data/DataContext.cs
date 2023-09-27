namespace YelpAgainstCompanies.Data;

public class DataContext : IdentityDbContext<AppUser, AppUserRole, Guid>
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
        //TODO Finish/fix this
        //TODO var guidString1 (and 2) = Guid.NewGuid().ToString();
        //TODO Enter these into Id = new Guid(guidString1/2),
        var userRowan = new AppUser
        {
            Id = new Guid("00000000-0000-0000-0000-000000000001"),
            Email = "rowan@email.com",
            EmailConfirmed = true,
            UserName = "rowan@email.com"
        };
        var userWednesday = new AppUser
        {
            Id = new Guid("00000000-0000-0000-0000-000000000002"),
            Email = "wednesday@asgard.com",
            EmailConfirmed = true,
            UserName = "wednesday@asgard.com"
        };

        builder.Entity<AppUser>().HasData(new AppUser[] { userRowan, userWednesday });

        var ratingWedndesdayAH = new Rating()
        {
            Id = 1,
            Date = new DateTime(2023, 4, 12),
            Score = 2.2,
            User = userWednesday,
            UserId = 2,
            Comment = "Terrible Company!",
            CompanyId = 2
        };
        var ratingRowanAH = new Rating()
        {
            Id = 2,
            Date = new DateTime(2023, 4, 15),
            Score = 1.75,
            User = userRowan,
            UserId = 1,
            Comment = "It sucks to work here.",
            CompanyId = 2
        };
        var ratingRowanBK = new Rating()
        {
            Id = 3,
            Date = new DateTime(2023, 6, 22),
            Score = 3.9,
            User = userRowan,
            UserId = 1,
            Comment = "This job was fine.",
            CompanyId = 3
        };
        var ratingWednesdayKB = new Rating()
        {
            Comment = "something",
            Date = new DateTime(2022, 9, 1),
            Id = 4,
            Score = 3,
            User = userWednesday,
            UserId = 2,
            CompanyId = 1
        };

        builder.Entity<Rating>().HasData(new Rating[] { ratingRowanAH,  ratingRowanBK, ratingWednesdayKB, ratingWedndesdayAH });

        var keesBalvert = new Company()
        {
            Id = 1,
            Name = "Kees Balvert",
            Ratings = new List<Rating>() { ratingWednesdayKB },
        };
        var albertHeijn = new Company()
        {
            Id = 2,
            Name = "Albert Heijn",
            Ratings = new List<Rating>
            {
                ratingRowanAH,
                ratingWedndesdayAH
            },
        };
        var burgerKing = new Company()
        {
            Id = 3,
            Name = "Burger King",
            Ratings = new List<Rating>
            {
                ratingRowanBK,
            }
        };

        builder.Entity<Company>().HasData(new Company[] { keesBalvert, albertHeijn, burgerKing });

        base.OnModelCreating(builder);
    }
}
