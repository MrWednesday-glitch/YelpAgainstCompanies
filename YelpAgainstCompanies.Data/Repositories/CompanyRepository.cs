namespace YelpAgainstCompanies.Data.Repositories;

[ExcludeFromCodeCoverage]
public class CompanyRepository : EFRepository<Company>, ICompanyRepository
{
    public CompanyRepository(DataContext dataContext) : base(dataContext)
    {        
    }

    public override async Task CreateRecord(Company entity)
    {
        //TODO Make validators to check if all the required fields are entered.

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
        return base.GetRecords();
    }

    public override Company GetRecord(int id)
    {
        //TODO Make connection with ratings here?

        return base.GetRecord(id);
    }

    public override async Task SaveChanges()
    {
        await base.SaveChanges();
    }
}
