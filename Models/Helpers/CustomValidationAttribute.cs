using System.ComponentModel.DataAnnotations;
using TPLOCAL1.Models.Enums;

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
                return new ValidationResult("Please provide a valid date", new string[] { validationContext.MemberName });
            }
            DateTime inputDate = (DateTime)value;
            DateTime refDate = new(2021, 1, 1);

            if (inputDate < refDate)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"Training Start Date should be before {refDate.ToString("dd/MM/yyyy")}", new string[] { validationContext.MemberName });
            }
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class GenderEnumValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Please select an option for gender", new string[] { validationContext.MemberName });
            }
            // from https://www.bytehide.com/blog/enum-to-list-csharp
            var resultArray = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToArray();
            // from https://stackoverflow.com/questions/472384/convert-an-array-of-enum-to-an-array-of-int
            int[] result = Array.ConvertAll(resultArray, value => (int)value); 
            int input = (int)value;

            if (!result.Contains(input))
            {
                return new ValidationResult("Please select an option for gender", new string[] { validationContext.MemberName });
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class TrainingTypeEnumValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Please select an option for training type", new string[] { validationContext.MemberName });
            }
            // from https://www.bytehide.com/blog/enum-to-list-csharp
            var resultArray = Enum.GetValues(typeof(TrainingType)).Cast<TrainingType>().ToArray();
            // from https://stackoverflow.com/questions/472384/convert-an-array-of-enum-to-an-array-of-int
            int[] result = Array.ConvertAll(resultArray, value => (int)value);
            int input = (int)value;

            if (!result.Contains(input))
            {
                return new ValidationResult("Please select an option for training type", new string[] { validationContext.MemberName });
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
