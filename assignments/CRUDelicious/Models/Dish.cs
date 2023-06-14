#pragma warning disable CS8618
namespace CRUDelicious.Models;
using System.ComponentModel.DataAnnotations;

public class Dish
{
    [Key] //primary key
    public int DishId { get; set; }

    [Required(ErrorMessage ="is required")]
    public string Name { get; set; }

    [Required(ErrorMessage ="is required")]
    public string Chef { get; set; }

    [Required(ErrorMessage = "is required and must be between 1 and 5")]
    [Range(1, 5)]
    public int Tastiness { get; set; }

    [Required(ErrorMessage = "is required and must be greater than 0")]
    [Range(0 , 10000)]
    public int Calories { get; set; }

    [Required(ErrorMessage = "is required")]
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}