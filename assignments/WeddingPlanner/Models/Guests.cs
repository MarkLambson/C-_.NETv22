#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;

public class Guest
{
    [Key]
    public int GuestId { get; set; } //<--- this is our AssociationId from the platform's wording
    public DateTime CreatedAt { get; set; } = DateTime.Now;


    // relationship properties below-------------------------------------------------------------//

    public int? UserId { get; set; } //added ? to int, got rid of error on WeddingController
    public User? User { get; set; }

    public int WeddingId { get; set; }
    public Wedding? Wedding { get; set; }
}