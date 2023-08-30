namespace YelpAgainstCompanies.Domain.Entities;

public class Company : EntityBase
{
    public Company()
    {
        Ratings = new List<Rating>();    
    }

    public string Name { get; set; } = string.Empty;

    public float Score { get; set; }

    public List<Rating> Ratings { get; set; } 
}
