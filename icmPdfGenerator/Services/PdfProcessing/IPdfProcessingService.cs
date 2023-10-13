using ICMPdfGenerator.Controllers;
using ICMPdfGenerator.DTOs.DTOModels.RATDTOs;

namespace ICMPdfGenerator.Services.PdfProcessing
{
    public interface IPdfProcessingService
    {
        string GenerateRATPdf(RATPDFDTOModel ratingDTO);
    }
}
