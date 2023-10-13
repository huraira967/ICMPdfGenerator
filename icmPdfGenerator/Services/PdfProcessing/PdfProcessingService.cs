using ICMPdfGenerator.Controllers;
using ICMPdfGenerator.DTOs.DTOModels.RATDTOs;
using ICMPdfGenerator.PdfTemplates.PdfModuleTemplates;
using ICMPdfGenerator.PdfTemplates.PdfModuleTemplates.RAT;
using ICMPdfGenerator.Services.PdfFoundationService;

namespace ICMPdfGenerator.Services.PdfProcessing
{
    public class PdfProcessingService : IPdfProcessingService
    {
        private readonly IPdfFoundationService pdfFoundationService;
        private readonly IPdfModulefTemplate pdfModulefTemplate;

        public PdfProcessingService(IPdfFoundationService pdfFoundationService, IPdfModulefTemplate pdfModulefTemplate)
        {
            this.pdfFoundationService = pdfFoundationService;
            this.pdfModulefTemplate = pdfModulefTemplate;
        }

        public string GenerateRATPdf(RATPDFDTOModel ratingDTO)
        {
            var rat = (IRATModuleTemplate)pdfModulefTemplate;
            var table = rat.RATResidentBasicInformation.GetBasicResidentInformation(ratingDTO.ResidentBasicInformation);
            var p = rat.Heading.GetHeading();
            pdfFoundationService.AddParagraph(p);
            pdfFoundationService.AddTable(table);
            return pdfFoundationService.GetDocumentPath();
        }
    }
}
