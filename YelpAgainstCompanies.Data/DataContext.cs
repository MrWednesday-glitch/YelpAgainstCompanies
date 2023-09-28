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
        //The seed entity for entity type 'Company' cannot be added because it has the navigation 'Ratings' set.
        //To seed relationships,  add the entity seed to 'Rating' and specify the foreign key values {'CompanyId'}.
        //Consider using 'DbContextOptionsBuilder.EnableSensitiveDataLogging' to see the involved property values.
        var guidStringRowan = Guid.NewGuid().ToString();
        var guidStringWednesday = Guid.NewGuid().ToString();

        var userRowan = new AppUser
        {
            Id = new Guid(guidStringRowan),
            Email = "rowan@email.com",
            EmailConfirmed = true,
            UserName = "rowan@email.com"
        };
        var userWednesday = new AppUser
        {
            Id = new Guid(guidStringWednesday),
            Email = "wednesday@asgard.com",
            EmailConfirmed = true,
            UserName = "wednesday@asgard.com"
        };

        var keesBalvert = new Company()
        {
            Id = 1,
            Name = "Kees Balvert",
            //Ratings = new List<Rating>() { ratingWednesdayKB },
        };
        var albertHeijn = new Company()
        {
            Id = 2,
            Name = "Albert Heijn",
            //Ratings = new List<Rating>
            //{
            //    ratingRowanAH,
            //    ratingWedndesdayAH
            //},
        };
        var burgerKing = new Company()
        {
            Id = 3,
            Name = "Burger King",
            //Ratings = new List<Rating>
            //{
            //    ratingRowanBK,
            //}
        };

        var ratingWednesdayAH = new Rating()
        {
            Id = 1,
            Date = new DateTime(2023, 4, 12),
            Score = 2.2,
            User = userWednesday,
            UserId = 2,
            Comment = "Terrible Company!",
            CompanyId = albertHeijn.Id,
            Company = albertHeijn,
        };
        var ratingRowanAH = new Rating()
        {
            Id = 2,
            Date = new DateTime(2023, 4, 15),
            Score = 1.75,
            User = userRowan,
            UserId = 1,
            Comment = "It sucks to work here.",
            CompanyId = albertHeijn.Id,
            Company = albertHeijn
        };
        var ratingRowanBK = new Rating()
        {
            Id = 3,
            Date = new DateTime(2023, 6, 22),
            Score = 3.9,
            User = userRowan,
            UserId = 1,
            Comment = "This job was fine.",
            CompanyId = burgerKing.Id,
            Company = burgerKing
        };
        var ratingWednesdayKB = new Rating()
        {
            Comment = "something",
            Date = new DateTime(2022, 9, 1),
            Id = 4,
            Score = 3,
            User = userWednesday,
            UserId = 2,
            CompanyId = keesBalvert.Id,
            Company = keesBalvert
        };

        //keesBalvert.Ratings.Add(ratingWednesdayKB);
        //albertHeijn.Ratings.Add(ratingRowanAH);
        //albertHeijn.Ratings.Add(ratingWednesdayAH);
        //burgerKing.Ratings.Add(ratingRowanBK);

        builder.Entity<Rating>()
            .HasOne(x => x.Company).WithMany(x => x.Ratings).HasForeignKey(x => x.CompanyId).IsRequired(false);

        builder.Entity<AppUser>().HasData(new AppUser[] { userRowan, userWednesday });
        builder.Entity<Rating>().HasData(new Rating[] { ratingRowanAH, ratingRowanBK, ratingWednesdayKB, ratingWednesdayAH });
        builder.Entity<Company>().HasData(new Company[] { keesBalvert, albertHeijn, burgerKing });

        base.OnModelCreating(builder);
    }
}
