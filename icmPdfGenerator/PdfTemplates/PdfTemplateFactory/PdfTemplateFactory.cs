using ICMPdfGenerator.PdfTemplates.PdfModuleTemplates;

namespace ICMPdfGenerator.PdfTemplates.PdfTemplateFactory
{
    public class PdfTemplateFactory : IPdfTemplateFactory
    {
        public T GetModuleTemplate<T>() where T : IPdfModulefTemplate, new()
        {
            return new T();
        }
    }
}
