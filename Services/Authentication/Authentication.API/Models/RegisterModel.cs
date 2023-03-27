using System.ComponentModel.DataAnnotations;

namespace Authentication.API.Models;

public class RegisterModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [StringLength(128)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(128)]
    public string LastName { get; set; }

}