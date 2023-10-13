using ICMPdfGenerator.DTOs.DTOModels.FacesheetDTOs;
using ICMPdfGenerator.DTOs.DTOModels.RATDTOs;
using ICMPdfGenerator.Services.PdfProcessing;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace ICMPdfGenerator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IPdfProcessingService PdfProcessingService;

        public HomeController(IPdfProcessingService pdfProcessingService)
        {
            PdfProcessingService = pdfProcessingService;
        }
       
        [Route("rat")]
        [HttpPost]
        public IActionResult ResidentAssessmentPDF(RATPDFDTOModel abc)
        {
            PdfProcessingService.GenerateRATPdf(abc);
            return Ok();
        }
        [HttpPost]
        [Route("facesheet")]
        public IActionResult I01ndex(FacesheetPDFDTOModel dto)
        {

            return Ok(dto);
        }
    }
}
