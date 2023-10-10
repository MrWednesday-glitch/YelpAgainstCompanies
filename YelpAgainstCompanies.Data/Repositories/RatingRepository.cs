namespace YelpAgainstCompanies.Data.Repositories;

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

    public override Rating GetRecord(int id)
    {
        return base.GetRecord(id);
    }

    public override IQueryable<Rating> GetRecords()
    {
        return base.GetRecords()
            .Include(x => x.User);
    }

    public override Task SaveChanges()
    {
        return base.SaveChanges();
    }
}
