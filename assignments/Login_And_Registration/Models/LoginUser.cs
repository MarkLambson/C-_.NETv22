namespace Login_And_Registration.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[NotMapped]//entire class not mapped to db
public class LoginUser
{
    [Required(ErrorMessage = "is required")]
    public string LoginEmail { get; set; }

    [Required(ErrorMessage = "is required")]
    [MinLength(8, ErrorMessage = "must be 8 characters long")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string LoginPassword { get; set; }
}