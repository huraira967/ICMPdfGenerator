using ICMPdfGenerator.PdfTemplates.PdfModuleTemplates.RAT.TemplateParts;

namespace ICMPdfGenerator.PdfTemplates.PdfModuleTemplates.RAT
{
    public class RATModuleTemplate : IPdfModulefTemplate, IRATModuleTemplate
    {
        public RATHeading Heading { get => (RATHeading)GetRATHeading(); }
        public RATResidentBasicInformation RATResidentBasicInformation { get => (RATResidentBasicInformation)GetBasicInformationPart(); } 
        
        private IRATTemplatePart GetBasicInformationPart()
        {
           return new RATResidentBasicInformation();
           
        }
        private IRATTemplatePart GetRATHeading()
        {
            return new RATHeading("Resident Assessment Tool");
        }
    }
}
