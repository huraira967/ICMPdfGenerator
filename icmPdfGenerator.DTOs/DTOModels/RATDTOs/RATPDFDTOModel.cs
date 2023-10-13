using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICMPdfGenerator.DTOs.DTOModels.RATDTOs
{
    public class RATPDFDTOModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FacilityId { get; set; }
        public ResidentBasicInformation ResidentBasicInformation { get; set; }
    }
}
