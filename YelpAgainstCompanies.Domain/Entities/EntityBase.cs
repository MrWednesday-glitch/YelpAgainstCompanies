namespace YelpAgainstCompanies.Domain.Entities;

[ExcludeFromCodeCoverage]
public class EntityBase
{
    public int Id { get; set; }

    public DateTime? DeletedDate { get; set; }
}
