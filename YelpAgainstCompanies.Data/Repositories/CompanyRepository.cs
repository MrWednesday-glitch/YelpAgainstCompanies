﻿namespace YelpAgainstCompanies.Data.Repositories;

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

    public override async Task DeleteRecord(Company company)
    {
        await base.DeleteRecord(company);
    }

    public override Task<IQueryable<Company>> GetRecords()
    {
        return base.GetRecords();
    }

    public override Task<Company> GetRecord(int id)
    {
        return base.GetRecord(id)
            ?? throw new CompanyDoesNotExistException($"/company/{id}");
    }

    public override async Task SaveChanges()
    {
        await base.SaveChanges();
    }
}
