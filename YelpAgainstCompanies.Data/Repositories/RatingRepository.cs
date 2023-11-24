namespace YelpAgainstCompanies.Data.Repositories;

[ExcludeFromCodeCoverage]
public class RatingRepository : EFRepository<Rating>, IRatingRepository
{
    public RatingRepository(DataContext dataContext) : base(dataContext)
    {
    }

    public override Task CreateRecord(Rating entity)
    {
        return base.CreateRecord(entity);
    }

    public override Task DeleteRecord(int id)
    {
        return base.DeleteRecord(id);
    }

    public override async Task<Rating> GetRecord(int id)
    {
        return await base.GetRecord(id);
    }

    public override async Task<IQueryable<Rating>> GetRecords()
    {
        return (await base.GetRecords())
            .Include(x => x.User);
    }

    public override Task SaveChanges()
    {
        return base.SaveChanges();
    }
}
