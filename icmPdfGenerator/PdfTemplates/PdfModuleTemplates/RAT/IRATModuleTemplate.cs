using ICMPdfGenerator.PdfTemplates.PdfModuleTemplates.RAT.TemplateParts;

namespace ICMPdfGenerator.PdfTemplates.PdfModuleTemplates.RAT
{
    public interface IRATModuleTemplate //Resident assessment tool Pdf Template strcuture holder interface
    {
         RATHeading Heading { get; }
        RATResidentBasicInformation RATResidentBasicInformation { get;}
    }
}
