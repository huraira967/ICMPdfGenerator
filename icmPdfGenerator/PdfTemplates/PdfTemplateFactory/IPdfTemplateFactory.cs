using ICMPdfGenerator.PdfTemplates.PdfModuleTemplates;

namespace ICMPdfGenerator.PdfTemplates.PdfTemplateFactory
{
    public interface IPdfTemplateFactory
    {
        T GetModuleTemplate<T>() where T : IiCMPdfModulefTemplate, new();
    }
}
