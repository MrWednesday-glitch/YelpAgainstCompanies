namespace YelpAgainstCompanies.Data.Repositories;

[ExcludeFromCodeCoverage]
public class CompanyRepository : EFRepository<Company>, ICompanyRepository
{
    public CompanyRepository(DataContext dataContext) : base(dataContext)
    {
    }

    public override async Task CreateRecord(Company entity)
    {
        if (entity.PictureUrl == null || entity.City == null || entity.Address == null || entity.Name == null || entity.PostalCode == null)
        {
            throw new Exception("You did not enter all the required fields.");
        }

        await base.CreateRecord(entity);
    }

    public override async Task DeleteRecord(int id)
    {
        if (GetRecords().SingleOrDefault(x => x.Id == id) == null)
        {
            throw new Exception("The Company you wish to delete does not exist.");
        }

        await base.DeleteRecord(id);
    }

    public override IQueryable<Company> GetRecords()
    {
        return base.GetRecords()
            .Include(x => x.Ratings)
            .ThenInclude(y => y.User);
    }

    public override Company GetRecord(int id)
    {
        return GetRecords().SingleOrDefault(x => x.Id == id)
            ?? throw new Exception("No record was found.");
    }

    public override async Task SaveChanges()
    {
        await base.SaveChanges();
    }
}
