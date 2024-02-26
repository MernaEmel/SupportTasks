using System.ComponentModel.DataAnnotations;
using SupportTask2.Models;
namespace SupportTask2.utilities
{
    public class CustomValidation2:ValidationAttribute
    {
     
        public CustomValidation2() {}
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Blog bl = (Blog)validationContext.ObjectInstance;
            int profit;
            if (!int.TryParse(value.ToString(), out profit))
            {
                return new ValidationResult("Enter integer value");
            }
            if (bl.IsFree && profit != 0)
            {
                return new ValidationResult("The profit must be 0 ,when the blog is free!");
            }
            return ValidationResult.Success;
        }

    }

}



