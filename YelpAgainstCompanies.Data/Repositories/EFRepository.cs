﻿namespace YelpAgainstCompanies.Data.Repositories;

[ExcludeFromCodeCoverage]
public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
{
    private readonly DataContext _dataContext;

    public EFRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public virtual async Task CreateRecord(TEntity entity)
    {
        await _dataContext.Set<TEntity>().AddAsync(entity);
    }

    public virtual async Task DeleteRecord(TEntity entity)
    {
        _dataContext.Set<TEntity>().Remove(entity);
    }

    public virtual async Task<IQueryable<TEntity>> GetRecords()
    {
        return _dataContext.Set<TEntity>().AsQueryable();
    }

    public virtual async Task<TEntity> GetRecord(int id)
    {
        var x = _dataContext.Set<TEntity>().SingleOrDefault(x => x.Id == id)!;
        return x;
    }

    public virtual async Task SaveChanges()
    {
        await _dataContext.SaveChangesAsync();
    }
}
