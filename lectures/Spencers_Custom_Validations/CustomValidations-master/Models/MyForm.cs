using System.ComponentModel.DataAnnotations;
namespace CustomValidations.Models;

public class MyForm
{
    [Required]
    [NoZNames]
    public string? Name {get;set;}
    // [Discount]
    [SelectOption("FREE99","PARTY")]
    public string? DiscountCode {get;set;}
    [Display(Name="Favorite Food")]
    [Required]
    [SelectOption("pizza","sushi","cake")]
    public string? FavoriteFood {get;set;}
    

}

public class NoZNamesAttribute : ValidationAttribute
{    
    // Call upon the protected IsValid method
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)    
    {   
        // We are expecting the value coming in to be a string
        // so we need to do a bit of type casting to our object
        // Strings work similarly to arrays under the hood 
        // so we can grab the first letter using its index   
        // If we discover that the first letter of our string is z...  

        if (value == null || ((string)value).ToLower()[0] == 'z')
        {        
            // we return an error message in ValidationResult we want to render    
            return new ValidationResult("No z names");   
        } else {   
            // Otherwise, we were successful and can report our success  
            return ValidationResult.Success;  
        }  
    }
}
public class DiscountAttribute : ValidationAttribute
{    
    // Call upon the protected IsValid method
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)    
    {   
        //this likely would come from a db later
        string[] Options = new string[]{"SAVE10", "RAIDSHADOWLEGENDS","FREE99"};

        if (value == null || Options.Contains((string)value))
        {        
            //We were successful and can report our success  
            return ValidationResult.Success;  
        } else {   
            //Otherwise we return an error message in ValidationResult we want to render    
            return new ValidationResult("Invalid discount code");   
        }  
    }
}

public class SelectOptionAttribute : ValidationAttribute
{    
    public string[]? Options {get;set;}

    public SelectOptionAttribute(params string[] options)
    {
        this.Options = options;
    }
    // Call upon the protected IsValid method
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)    
    {   

        if (value == null || Options.Contains((string)value))
        {        
            // We were successful and can report our success  
            return ValidationResult.Success;  
        } else {   
            // otherwise we return an error message in ValidationResult we want to render    
            return new ValidationResult("Please choose a valid option and/or stop hacking my site");   
        }  
    }
}



