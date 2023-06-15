#pragma warning disable CS8618
namespace EFLectures.Models;
using System.ComponentModel.DataAnnotations;

public class Post
{
    [Key] //primary key
    public int PostId { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "2 or more characters")]
    [MaxLength(30, ErrorMessage = "cannot be longer than 30 characters")]
    public string Topic { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "2 or more characters")]
    public string Body { get; set; }

    [Display(Name = "Image URL")]
    public string? ImgUrl { get; set; }

    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;

// relationship properties below-------------------------------------------------------------//

// One to Many (left join)
    public int UserId { get; set; } //has to match primary key name (UserID) from User.cs
    public User? Author { get; set; } //difference between this and above is this is pointed to by the UserId above, this Author object is the actual User model in db
}