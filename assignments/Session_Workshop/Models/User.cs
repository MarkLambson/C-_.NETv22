namespace Session_Workshop.Models;
using System.ComponentModel.DataAnnotations;

public class User
{
    [Required(ErrorMessage = "is required")]
    public string Name { get; set; }
}