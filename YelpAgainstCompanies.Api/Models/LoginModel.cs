namespace YelpAgainstCompanies.Api.Models;

//TODO Add first name and laster name
public class LoginModel
{
    [Required(AllowEmptyStrings = false)]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    public bool RememberMe { get; set; }
}
