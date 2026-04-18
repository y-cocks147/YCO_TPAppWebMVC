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
    }
}
