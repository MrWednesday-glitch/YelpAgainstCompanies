﻿namespace YelpAgainstCompanies.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
}
