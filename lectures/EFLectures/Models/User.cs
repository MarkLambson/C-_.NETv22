#pragma warning disable CS8618
namespace EFLectures.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required(ErrorMessage = "is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "is required")]
    [EmailAddress]
    [UniqueEmail]
    public string Email { get; set; }

    [Required(ErrorMessage = "is required")]
    [MinLength(8, ErrorMessage = "must be at least 8 characters")]
    [DataType(DataType.Password)] // input shows up as dots, user cant see while typing, does nothing to db
    public string Password { get; set; }

    [NotMapped]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "must match Password")] //comparing with password field input
    public string PasswordConfirm { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

// relationship properties below-------------------------------------------------------------//

    public List<Post> CreatedPosts { get; set; } = new List<Post>(); // default to new empty List<Post>, do not '?' nullable
    public List<UserPostLike> LikedPosts { get; set; } = new List<UserPostLike>();
}

// ADD CUSTOM VALIDATIONS BELOW

public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {

        if (value == null)
        {
            return new ValidationResult("Email is required");
        }
        MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext));
        if (_context.Users.Any(e => e.Email == value.ToString()))
        {
            return new ValidationResult("Email is already taken!");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}