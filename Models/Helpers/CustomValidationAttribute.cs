using System.ComponentModel.DataAnnotations;
using System.Numerics;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

// https://stackoverflow.com/questions/29032705/date-input-validation-asp-net
namespace TPLOCAL1.Models.Helpers
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LessDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) 
            {
                return new ValidationResult("Please provide a valid date.", new string[] { validationContext.MemberName });
            }
            DateTime inputDate = (DateTime)value;
            DateTime refDate = new(2021, 1, 1);

            if (inputDate < refDate)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"TrainingStartDate should be before {refDate.ToString("dd/MM/yyyy")}", new string[] { validationContext.MemberName });
            }
        }
    }
}
