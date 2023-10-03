namespace YelpAgainstCompanies.Data.Repositories;

public class RatingRepository : EFRepository<Rating>, IRatingRepository
{
    public RatingRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
