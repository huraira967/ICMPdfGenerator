using ICMPdfGenerator.PdfTemplates.PdfModuleTemplates;
using ICMPdfGenerator.TemplateConfigurations;

namespace ICMPdfGenerator.PdfTemplates.PdfTemplateFactory
{
    public interface IPdfTemplateFactory
    {
        T GetModuleTemplate<T>() where T : IPdfModulefTemplate, new();
    }
}
