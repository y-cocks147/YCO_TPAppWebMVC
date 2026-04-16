using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using TPLOCAL1.Models.Enums;

namespace TPLOCAL1.Models.Helpers
{
    public class ConvertEnumToItem
    {
        public int Value { get; set; }
       
        public string Text { get; set; }

        public static SelectList GetGenderSelectList()
        {
            var genderConvertEnum = new List<ConvertEnumToItem>();
            foreach (Gender gender in Enum.GetValues(typeof(Gender)))
                genderConvertEnum.Add(new ConvertEnumToItem
                {
                    Value = (int)gender,
                    Text = gender.ToString()
                });

            return new SelectList(genderConvertEnum, "Value", "Text");
        }

        public static SelectList GetTrainingTypeSelectList()
        {
            var trainingTypeConvertEnum = new List<ConvertEnumToItem>();
            foreach (TrainingType trainingType in Enum.GetValues(typeof(TrainingType)))
                trainingTypeConvertEnum.Add(new ConvertEnumToItem
                {
                    Value = (int)trainingType,
                    Text = trainingType.ToString()
                });

            return new SelectList(trainingTypeConvertEnum, "Value", "Text");
        }
    }
}
