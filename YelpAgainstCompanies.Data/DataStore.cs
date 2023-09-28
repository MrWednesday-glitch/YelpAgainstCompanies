namespace YelpAgainstCompanies.Data;

[ExcludeFromCodeCoverage]
public class DataStore
{
    public async Task<List<Company>> GetCompanies()
    {
        var userRowan = new AppUser
        {
            Id = new Guid("pre generated value 1"),
            Email = "rowan@email.com",
            EmailConfirmed = true,
            UserName = "rowan@email.com"
        };
        var userWednesday = new AppUser
        {
            Id = new Guid("pre generated value 2"),
            Email = "wednesday@asgard.com",
            EmailConfirmed = true,
            UserName = "wednesday@asgard.com"
        };

        //var userRowan = new User()
        //{
        //    FirstName = "Rowan",
        //    LastName = "Chander",
        //    Email = "rowan@gmail.com",
        //    Id = 1
        //};
        //var userWednesday = new User()
        //{
        //    FirstName = "Wednesday",
        //    LastName = "Asriel",
        //    Email = "wednesday@asgard.com",
        //    Id = 2
        //};

        var ratingWedndesdayAH = new Rating()
        {
            Id = 1,
            Date = new DateTime(2023, 4, 12),
            Score = 2.2,
            User = userWednesday,
            UserId = userWednesday.Id,
            Comment = "Terrible Company!"
        };
        var ratingRowanAH = new Rating()
        {
            Id = 2,
            Date = new DateTime(2023, 4, 15),
            Score = 1.75,
            User = userRowan,
            UserId = userRowan.Id,
            Comment = "It sucks to work here."
        };
        var ratingRowanBK = new Rating()
        {
            Id = 3,
            Date = new DateTime(2023, 6, 22),
            Score = 3.9,
            User = userRowan,
            UserId = userRowan.Id,
            Comment = "This job was fine."
        };
        var ratingWednesdayKB = new Rating()
        {
            Comment = "something",
            Date = new DateTime(2022, 9, 1),
            Id = 4,
            Score = 3,
            User = userWednesday,
            UserId = userWednesday.Id,
        };

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

        keesBalvert.Score = keesBalvert.Ratings.Average(x => x.Score);
        albertHeijn.Score = albertHeijn.Ratings.Average(x => x.Score);
        burgerKing.Score = burgerKing.Ratings.Average(x => x.Score);

        var companies = new List<Company>()
        {
            keesBalvert,
            albertHeijn,
            burgerKing
        };

        return companies;
    }
}