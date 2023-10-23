using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace ICMPdfGenerator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TempController : ControllerBase
    {
        [Route("abc")]
        [HttpGet]
        public IActionResult ResidentAssessmentPDF()
        {
            DateOnlyConverter converter = new DateOnlyConverter();
            DateOnly a = (DateOnly)converter.ConvertFrom(DateTime.Now.Date);
            return Ok(a);
        }

    }
}
