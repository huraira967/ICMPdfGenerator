using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICMPdfGenerator.DTOs.DTOModels.RATDTOs
{
    public class ResidentBasicInformation
    {
        public string Name { get; set; } = "Huraira";
        public double Age { get; set; } = 23.5;
        public string Language { get; set; } = "Urdu";
        public string Gender { get; set; } = "Male";
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public string Nationality { get; set; } = "Pakistani";
        
    }
}
