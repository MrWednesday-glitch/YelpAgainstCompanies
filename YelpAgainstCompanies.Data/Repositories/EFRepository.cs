namespace YelpAgainstCompanies.Data.Repositories;

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

    public virtual async Task DeleteRecord(int id)
    {
        _dataContext.Set<TEntity>().Remove(await GetRecord(id));
    }

    public virtual async Task<IQueryable<TEntity>> GetRecords()
    {
        return _dataContext.Set<TEntity>().AsQueryable();
    }

    public virtual async  Task<TEntity> GetRecord(int id)
    {
        return _dataContext.Set<TEntity>().SingleOrDefault(x => x.Id == id)!;
    }

    public virtual async Task SaveChanges()
    {
        await _dataContext.SaveChangesAsync();
    }
}
