using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using TPLOCAL1.Models.Enums;

namespace TPLOCAL1.Models.Helpers
{
    public class GenerateSelectList
    {
        public SelectList? GenderSelectList { get; set; }
        public SelectList? TrainingTypeSelectList { get; set; }

        public GenerateSelectList()
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

            GenderSelectList = new SelectList(genderConvertEnum, "Value", "Text");

            var trainingTypeConvertEnum = new List<ConvertEnumToItem>();
            foreach (TrainingType trainingType in Enum.GetValues(typeof(TrainingType)))
            {
                trainingTypeConvertEnum.Add(new ConvertEnumToItem
                {
                    Value = (int)trainingType,
                    Text = AddSpacesToString(trainingType.ToString())
                });
            }

            TrainingTypeSelectList = new SelectList(trainingTypeConvertEnum, "Value", "Text");
        }

        // from https://stackoverflow.com/questions/272633/add-spaces-before-capital-letters
        private string AddSpacesToString(string text, bool preserveAcronyms = false)
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
