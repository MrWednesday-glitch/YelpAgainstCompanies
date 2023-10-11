namespace YelpAgainstCompanies.Api.Models;

//TODO Add first name and laster name => How do I make it that entering the first name and last name is not required at the login level
public class LoginModel
{
    [Required(AllowEmptyStrings = false)]
    public string FirstName { get; set; }

    public string? LastName { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    public bool RememberMe { get; set; }
}
