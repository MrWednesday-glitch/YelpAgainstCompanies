namespace YelpAgainstCompanies.Domain.Interfaces;

/// <summary>
/// An interface of all the basic functionality (give or take) that a connection to the database should have (CRUD).
/// </summary>
/// <typeparam name="TEntity">A generic class, ensuring that this can be used for, among others, both Company and Rating.</typeparam>
public interface IRepository<TEntity> where TEntity : EntityBase
{
    /// <summary>
    /// Deletes a record from the database based on a given id.
    /// </summary>
    /// <param name="id">The id of the record that needs to be deleted.</param>
    /// <returns></returns>
    Task DeleteRecord(int id);

    /// <summary>
    /// Retrieves all the records from the database of type TEntity.
    /// </summary>
    /// <returns>A collection of entities.</returns>
    IQueryable<TEntity> GetRecords();

    /// <summary>
    /// Retrieves an existing record from the database as an entity object.
    /// </summary>
    /// <param name="id">the id that corresponds with a record.</param>
    /// <returns>The record as an object of type TEntity.</returns>
    TEntity GetRecord(int id);

    /// <summary>
    /// Adds a created TEntity object as a records in the database.
    /// </summary>
    /// <param name="entity">The object to be added into the database.</param>
    /// <returns></returns>
    Task CreateRecord(TEntity entity);

    /// <summary>
    /// Sends the commands to the database to be executed.
    /// </summary>
    /// <returns></returns>
    Task SaveChanges();
}
