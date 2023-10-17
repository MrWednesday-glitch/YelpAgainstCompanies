﻿using System.Data.Entity;

namespace YelpAgainstCompanies.Business.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<IEnumerable<Company>> Get()
    {
        var companies = _companyRepository.GetRecords()
            .OrderBy(x => x.Name)
            .ThenBy(y => y.City);

        return companies;
    } 

    public async Task<Company> Get(int id)
    {
        var company = _companyRepository.GetRecord(id)
            ?? throw new ArgumentNullException("No company was found with this id.");

        return company;
    }

    public async Task Create(Company company)
    {
        if (await ExistingCompanyInDB(company) != null)
        {
            throw new Exception("The company you tried to create already exists.");
        }

        await _companyRepository.CreateRecord(company);
        await _companyRepository.SaveChanges();
    }

    private async Task<Company?> ExistingCompanyInDB(Company company) =>
        _companyRepository.GetRecords()
            .SingleOrDefault(x => 
                x.Name == company.Name && 
                x.PostalCode == company.PostalCode);
}
