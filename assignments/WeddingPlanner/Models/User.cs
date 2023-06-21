#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;

public class User
{
    [Key]
    public int UserId { get; set; }
    
    [Display(Name = "First Name: ")]
    [Required(ErrorMessage = "First Name is required")]
    [MinLength(2, ErrorMessage = "First Name must be at least 2 characters in length")]
    public string FirstName { get; set; }

    [Display(Name = "Last Name: ")]
    [Required(ErrorMessage = "Last Name is required")]
    [MinLength(2, ErrorMessage = "Last Name must be at least 2 characters in length")]
    public string LastName { get; set; }

    [Display(Name = "Email: ")]
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Must be a valid email address")]
    [UniqueEmail]
    public string Email { get; set; }

    [Display(Name = "Password: ")]
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters in length")]
    public string Password { get; set; }

    [Display(Name = "Confirm Password: ")]
    [Required(ErrorMessage = "Confirm Password is required")]
    [DataType(DataType.Password)]
    [NotMapped]
    // built-in to compare field to "Password"
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string PasswordConfirm { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // relationship properties below-------------------------------------------------------------//


    public List<Guest> AllGuests { get; set; } = new List<Guest>();
    // public List<Wedding> CreatedWeddings { get; set; } = new List<Wedding>();
}



//unique email check-----------------------------------------------------------------------------//
public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        // Though we have Required as a validation, sometimes we make it here anyways
        // In which case we must first verify the value is not null before we proceed
        if (value == null)
        {
            // If it was, return the required error
            return new ValidationResult("Email is required!");
        }

        // This will connect us to our database since we are not in our Controller
        MyContext db = (MyContext)validationContext.GetService(typeof(MyContext));
        // Check to see if there are any records of this email in our database
        if (db.Users.Any(e => e.Email == value.ToString()))
        {
            // If yes, throw an error
            return new ValidationResult("Email must be unique!");
        }
        else
        {
            // If no, proceed
            return ValidationResult.Success;
        }
    }
}