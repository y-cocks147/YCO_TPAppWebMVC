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
        public string? Adress { get; set; }
        [Required]
        [Display(Name = "Zip Code")]
        [RegularExpression(@"^\d{5}$")] // ^\d{5}(?:-\d{4})?$ for optional 4 digits
        public string? ZipCode { get; set; }
        [Required]
        public string? Town { get; set; }
        [Required]
        [Display(Name = "Email Adress")]
        [RegularExpression(@"^([\w]+)@([\w]+)\.([\w]+)$")]
        public string? EmailAdress { get; set; }
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
        [Display(Name = "C# Training Review")]
        public string? ObjectTrainingOpinion { get; set; }

    }
}
