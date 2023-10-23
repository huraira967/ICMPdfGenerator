using ICMPdfGenerator.DTOs.DTOModels.RATDTOs;
using ICMPdfGenerator.ICMProperties.Enums;
using ICMPdfGenerator.Models.ICMPdfLayout.Elements;
using ICMPdfGenerator.PdfTemplates.PdfModuleTemplates;
using ICMPdfGenerator.PdfTemplates.PdfModuleTemplates.RAT;
using ICMPdfGenerator.Services.PdfFoundationService;

namespace ICMPdfGenerator.Services.PdfProcessing
{
    public class PdfProcessingService : IPdfProcessingService
    {
        private readonly IIText7PdfFoundationService pdfFoundationService;
        private readonly IiCMPdfModulefTemplate pdfModulefTemplate;

        public PdfProcessingService(IIText7PdfFoundationService pdfFoundationService, IiCMPdfModulefTemplate pdfModulefTemplate)
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
            var dottedline = new Line(LineType.Dashed);
            //dottedline.Gap = 10;
            dottedline.LineColor = Color.BLUE;
            dottedline.LineWidth = 5;
            LineSeparator lineSeparator = new LineSeparator(dottedline);
            lineSeparator.Styles.Margin = new Margin(5);
            pdfFoundationService.AddLineSeparator(lineSeparator);

            pdfFoundationService.AddSpace(120);
            pdfFoundationService.AddPageBreak();

            pdfFoundationService.AddTable(table);



            return pdfFoundationService.GetDocumentPath();
        }
    }
}
