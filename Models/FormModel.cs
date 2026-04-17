using System.ComponentModel.DataAnnotations;
using TPLOCAL1.Models.Enums;

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
        [Required]
        public Gender Gender { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)] // longest address is 85 char according to https://en.wikipedia.org/wiki/List_of_long_place_names
        public string? Address { get; set; }
        [Required]
        [Display(Name = "Zip Code")]
        [RegularExpression(@"^\d{5}$")] // ^\d{5}(?:-\d{4})?$ for optional 4 digits
        public string? ZipCode { get; set; }
        [Required]
        public string? Town { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        [RegularExpression(@"^([\w]+)@([\w]+)\.([\w]+)$")]
        public string? EmailAddress { get; set; }
        [Required]
        [Display(Name = "Training Start Date")]
        [DataType(DataType.Date)]
        public DateTime TrainingStartDate { get; set; }
        [Required]
        [Display(Name = "Training Type")]
        public TrainingType TrainingType { get; set; }
        [Required]
        [Display(Name = "Cobol Training Review")]
        public string? CobolTrainingOpinion { get; set; }
        [Required]
        [Display(Name = "Object Training Review")]
        public string? ObjectTrainingOpinion { get; set; }
    }
}
