using System.ComponentModel.DataAnnotations;
using TPLOCAL1.Models.Enums;
using TPLOCAL1.Models.Helpers;

namespace TPLOCAL1.Models
{
    public class FormModel
    {
        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; } // Last name / Name
        [Required]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; } // First Name / Forename
        [Required(ErrorMessage = "Select an option for Gender")]
        [GenderEnumValidation()]
        public Gender Gender { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Address too short", MinimumLength = 5)] // longest address is 85 char according to https://en.wikipedia.org/wiki/List_of_long_place_names
        public string? Address { get; set; }
        [Required]
        [Display(Name = "Zip Code")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Must be 5 digits exp : 75000")] // ^\d{5}(?:-\d{4})?$ for optional 4 digits
        public string? ZipCode { get; set; }
        [Required]
        public string? Town { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        [RegularExpression(@"^([\w]+)@([\w]+)\.([\w]+)$", ErrorMessage = "Must be a valid email adress exp : youremail@server.domain")]
        public string? EmailAddress { get; set; }
        [Required]
        [Display(Name = "Training Start Date")]
        [DataType(DataType.Date, ErrorMessage = "Please provide a valid date.")]
        [LessDateValidation()]
        //[DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime? TrainingStartDate { get; set; }
        [Required]
        [Display(Name = "Training Type")]
        [TrainingTypeEnumValidation()]
        public TrainingType TrainingType { get; set; }
        [Display(Name = "Cobol Training Review")]
        public string? CobolTrainingOpinion { get; set; }
        [Display(Name = "Object Training Review")]
        public string? ObjectTrainingOpinion { get; set; }
    }
}
