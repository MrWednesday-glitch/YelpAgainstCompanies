﻿namespace YelpAgainstCompanies.Data;

[ExcludeFromCodeCoverage]
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
        if (!optionsBuilder.IsConfigured)
        {
            var configBuilder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", false, true)
                    .Build();

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(configBuilder.GetConnectionString("DefaultConnection"));
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        var guidStringRowan = Guid.NewGuid().ToString();
        var guidStringWednesday = Guid.NewGuid().ToString();

        var userRowan = new AppUser
        {
            Id = new Guid(guidStringRowan),
            Email = "rowan@email.com",
            EmailConfirmed = true,
            UserName = "rowan@email.com",
            FirstName = "Rowan",
            LastName = "X"
        };
        var userWednesday = new AppUser
        {
            Id = new Guid(guidStringWednesday),
            Email = "wednesday@asgard.com",
            EmailConfirmed = true,
            UserName = "wednesday@asgard.com",
            FirstName = "Wednesday",
            LastName = "Y"
        };

        var keesBalvert = new Company()
        {
            Id = 1,
            Name = "Kees Balvert",
            Address = "Street 5",
            PostalCode = "1234XD",
            City = "Den Haag",
            Score = 3,
            PictureUrl = "https://cdn.autotrack.nl/18126/0-438b7d7d-c717-484c-b4a7-81e6a4df20ae.jpg?w=320",
            DeletedDate = null,
        };
        var albertHeijn = new Company()
        {
            Id = 2,
            Name = "Albert Heijn",
            Address = "Dorpstraat 3",
            City = "Zoetermeer",
            PostalCode = "2345RT",
            Score = 1.975,
            PictureUrl = "https://media.prdn.nl/retailtrends/files/RetailTrends/Albert+Heijn+5.jpg",
            DeletedDate = null,
        };
        var burgerKing = new Company()
        {
            Id = 3,
            Name = "Burger King",
            Address = "Kaaglaan 66",
            City = "Den Haag",
            PostalCode = "6666YY",
            Score = 3.9,
            PictureUrl = "https://st3.idealista.com/news/archivos/styles/imagen_big_lightbox/public/2020-03/burger_king.jpg?sv=TGX70G_u&itok=fWgVKuuM",
            DeletedDate = null,
        };

        var ratingWednesdayAH = new Rating()
        {
            Id = 1,
            Date = new DateTime(2023, 4, 12),
            Score = 2.2,
            UserId = userWednesday.Id,
            Comment = "Terrible Company!",
            CompanyId = albertHeijn.Id,
            DeletedDate = null,
        };
        var ratingRowanAH = new Rating()
        {
            Id = 2,
            Date = new DateTime(2023, 4, 15),
            Score = 1.75,
            UserId = userRowan.Id,
            Comment = "It sucks to work here.",
            CompanyId = albertHeijn.Id,
            DeletedDate = null,
        };
        var ratingRowanBK = new Rating()
        {
            Id = 3,
            Date = new DateTime(2023, 6, 22),
            Score = 3.9,
            UserId = userRowan.Id,
            Comment = "This job was fine.",
            CompanyId = burgerKing.Id,
            DeletedDate = null,
        };
        var ratingWednesdayKB = new Rating()
        {
            Comment = "something",
            Date = new DateTime(2022, 9, 1),
            Id = 4,
            Score = 3,
            UserId = userWednesday.Id,
            CompanyId = keesBalvert.Id,
            DeletedDate = null,
        };

        builder.Entity<AppUser>().HasData(new AppUser[] { userRowan, userWednesday });
        builder.Entity<Rating>().HasData(new Rating[] { ratingRowanAH, ratingRowanBK, ratingWednesdayKB, ratingWednesdayAH });
        builder.Entity<Company>().HasData(new Company[] { keesBalvert, albertHeijn, burgerKing });

        // This does not work...
        //builder.Entity<EntityBase>().HasQueryFilter(b => b.DeletedDate == null);

        builder.Entity<Company>().HasQueryFilter(company => company.DeletedDate == null);
        builder.Entity<Rating>().HasQueryFilter(rating => rating.DeletedDate == null);

        base.OnModelCreating(builder);
    }
}
