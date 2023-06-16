#pragma warning disable CS8618
namespace EFLectures.Models;
using System.ComponentModel.DataAnnotations;


public class UserPostLike
{
    [Key]
    public int UserPostLikeId { get; set; }
// add public string Details for a comment instead of like

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    // public DateTime UpdatedAt { get; set; } = DateTime.Now; 
    // dont really need this for likes, you cant "update" likes other than deleting it

// relationships below------------------------------------------------------//
    public int UserId { get; set; }
    public User? User { get; set; }

    public int PostId { get; set; }
    public Post? Post { get; set; }
}