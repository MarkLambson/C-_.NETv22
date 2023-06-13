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
}