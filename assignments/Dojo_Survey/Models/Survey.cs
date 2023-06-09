namespace Dojo_Survey.Models;
using System.ComponentModel.DataAnnotations;
// ^ include namespace for models and System.ComponentModel.DataAnnotations for validations 

public class Survey
//public for the people!
{
    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters long")]
    //all validations above properties
    public string Name { get; set; }

    [Required(ErrorMessage = "is required")]
    public string Location { get; set; }

    [Required(ErrorMessage = "is required")]
    public string Language { get; set; }

    [Range(20,250)]
    public string? Comment { get; set; }
    //include ? for null
}