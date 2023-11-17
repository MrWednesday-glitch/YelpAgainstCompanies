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
        _dataContext.Set<TEntity>().Remove(GetRecord(id));
    }

    public virtual IQueryable<TEntity> GetRecords()
    {
        return _dataContext.Set<TEntity>().AsQueryable();
    }

    public virtual TEntity GetRecord(int id)
    {
        return _dataContext.Set<TEntity>().SingleOrDefault(x => x.Id == id)!;
    }

    public virtual async Task SaveChanges()
    {
        await _dataContext.SaveChangesAsync();
    }
}
