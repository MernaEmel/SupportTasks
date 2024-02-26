using System.ComponentModel.DataAnnotations;
using SupportTask2.Models;
namespace SupportTask2.utilities
{
    public class CustomValidation1:ValidationAttribute
    {
        private readonly int _MaxProfit;
        public CustomValidation1(int Profit)
        {
            _MaxProfit = Profit;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Blog b = (Blog)validationContext.ObjectInstance;
            int profit;
            if(!int.TryParse(value.ToString(), out profit))
            {
                return new ValidationResult("Enter integer value");
            }
            if (b.TypeId==1&& profit>_MaxProfit)
            {
                return new ValidationResult("ActionBlog profit must be less than" +_MaxProfit.ToString());
            }
            return ValidationResult.Success;

        }

    }
}



