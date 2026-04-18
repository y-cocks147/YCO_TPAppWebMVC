using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using TPLOCAL1.Models.Enums;

namespace TPLOCAL1.Models.Helpers
{
    public class ConvertEnumToItem
    {
        public int Value { get; set; }
        public string? Text { get; set; }

        public static SelectList GetGenderSelectList()
        {
            var genderConvertEnum = new List<ConvertEnumToItem>();
            foreach (Gender gender in Enum.GetValues(typeof(Gender)))
            {
                genderConvertEnum.Add(new ConvertEnumToItem
                {
                    Value = (int)gender,
                    Text = AddSpacesToString(gender.ToString())
                });
            }

            return new SelectList(genderConvertEnum, "Value", "Text");
        }

        public static SelectList GetTrainingTypeSelectList()
        {
            var trainingTypeConvertEnum = new List<ConvertEnumToItem>();
            foreach (TrainingType trainingType in Enum.GetValues(typeof(TrainingType)))
            {
                trainingTypeConvertEnum.Add(new ConvertEnumToItem
                {
                    Value = (int)trainingType,
                    Text = AddSpacesToString(trainingType.ToString())
                });
            }

            return new SelectList(trainingTypeConvertEnum, "Value", "Text");
        }

        // from https://stackoverflow.com/questions/272633/add-spaces-before-capital-letters
        private static string AddSpacesToString(string text, bool preserveAcronyms = false)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                    if ((text[i - 1] != ' ' && !char.IsUpper(text[i - 1])) ||
                        (preserveAcronyms && char.IsUpper(text[i - 1]) &&
                         i < text.Length - 1 && !char.IsUpper(text[i + 1])))
                        newText.Append(' ');
                newText.Append(text[i]);
            }
            return newText.ToString();
        }
    }
}
