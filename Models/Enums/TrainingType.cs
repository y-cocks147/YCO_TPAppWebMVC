using System.ComponentModel.DataAnnotations;

namespace TPLOCAL1.Models.Enums
{
    public enum TrainingType
    {
        [Display(Name = "Cobol Traning")]
        CobolTraning = 1,
        [Display(Name = "Object Training")]
        ObjectTraining = 2,
        [Display(Name = "Dual Skills Training")]
        DualSkillsTraining = 3
    }
}
