namespace Petstagram.Models;
using System.ComponentModel.DataAnnotations;

public class Pet 
{
    [Required(ErrorMessage = "is required")] 
    public string Name { get; set; }

    [Required(ErrorMessage = "is required")]
    [Display(Name="Pet Type")]
    public string Type { get; set; }

    [Range(0, 120)]
    [Display(Name="Pet Age")]
    public int Age { get; set; }
}