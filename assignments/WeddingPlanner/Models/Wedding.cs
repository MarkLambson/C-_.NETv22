#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;

public class Wedding
{
    [Key]
    public int WeddingId { get; set; }

    [Display(Name = "Wedder One: ")]
    [Required(ErrorMessage = "Wedder One is required")]
    public string WedderOne { get; set; }


    [Display(Name = "Wedder Two: ")]
    [Required(ErrorMessage = "Wedder Two is required")]
    public string WedderTwo { get; set; }


    [Display(Name = "Date: ")]
    [Required(ErrorMessage = "Date is required")]
    [DataType(DataType.Date)]
    [FutureDate]
    public DateTime? Date { get; set; } //name this something more specific in the future :)


    [Display(Name = "Address: ")]
    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // relationship properties below-------------------------------------------------------------//

    public int UserId { get; set; }

    // public User? Creator { get; set; } //<--- ONLY NEEDED TO SEE PERSON DISPLAYING THE WEDDING, DID NOT USE IN WEDPLAN

    public List<Guest> AllGuests { get; set; } = new List<Guest>();
}


    // date in future check ----------------------------------------------------------------------//
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // First verify the value is not null before we proceed
            if (value == null)
            {
            // If null, yeet the required error
                return new ValidationResult("Must provide a wedding date!");
            }
            // Check to see if DateTime is less than or equal to current DateTime
            if ((DateTime)value <= DateTime.Now.Date)
            {
            // If yes, yeet an error
                return new ValidationResult("Wedding must be in the future!");
            }
            else
            {
                // If no, proceed as normal
                return ValidationResult.Success;
            }
        }
    }
