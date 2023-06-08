namespace Petstagram.Models;
using System.ComponentModel.DataAnnotations;

public class Pet 
{
    [Required(ErrorMessage = "is required")] 
    [NoZNames]
    public string Name { get; set; }

    [Required(ErrorMessage = "is required")]
    [Display(Name="Pet Type")]
    // [SelectOption("Dog", "Cat", "Bird")]    <---this is the dropdown menu thing at the bottom of this page//
    public string Type { get; set; }

    [Range(0, 120)]
    [Display(Name="Pet Age")]
    public int Age { get; set; }
}

public class NoZNamesAttribute : ValidationAttribute //<-- comes from ASP, built in
{
    // Call upon the protected IsValid method
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // We are expecting the value coming in to be a string
        // so we need to do a bit of type casting to our object
        // Strings work similarly to arrays under the hood 
        // so we can grab the first letter using its index   
        // If we discover that the first letter of our string is z...  
        if (((string)value).ToLower()[0] == 'z')
        {
            // we return an error message in ValidationResult we want to render    
            return new ValidationResult("No names that start with Z allowed! Get out of here you Z namers...");
        }
        else
        {
            // Otherwise, we were successful and can report our success  
            return ValidationResult.Success;
        }
    }
}

// public class DiscountAttribute : ValidationAttribute                                                    <-- this is an example for a discount code, both checking if it is empty and if it is correct from a list we create
// protected override ValidationResult IsValid(object value, ValidationContext validationContext)
// {
//this likely would come from a DB later on
// string[] Options = new string[]{"SAVE10", "RAIDSHADOWLEGENDS", "FREE99"};

// if (value == null || Options.Contains((string)value))
//         {
//             return ValidationResult.Success;
//         } else {
//             return new ValidationResult("Invalid discount code");
//         }
// }





// public class SelectOptionAttribute : ValidationAttribute                                                     <-- this is an example of a dropdown menu//
// {
    // public string[] Options { get; set; }
//line 64-67 is a constructor for the dropdown menu//
    // public SelectOptionAttribute(params string[] options)
    // {
    //     this.Options = options;
    // }
// protected override ValidationResult IsValid(object value, ValidationContext validationContext)
// {
//this likely would come from a DB later on//
// string[] Options = new string[]{"SAVE10", "RAIDSHADOWLEGENDS", "FREE99"};

// if (value == null || Options.Contains((string)value))
//         {
//             return ValidationResult.Success;
//         } else {
//             return new ValidationResult("Invalid discount code");
//         }
// }