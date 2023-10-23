using ICMPdfGenerator.PdfTemplates.PdfModuleTemplates;

namespace ICMPdfGenerator.PdfTemplates.PdfTemplateFactory
{
    public class ICMPdfTemplateFactory : IPdfTemplateFactory
    {
        public T GetModuleTemplate<T>() where T : IiCMPdfModulefTemplate, new()
        {
            return new T();
        }
    }
}
