using ICMPdfGenerator.Controllers;
using ICMPdfGenerator.DTOs.DTOModels.RATDTOs;

namespace ICMPdfGenerator.Services.PdfProcessing
{
    public interface IPdfProcessingService
    {
        void GenerateRATPdf(RATPDFDTOModel ratingDTO);
    }
}
