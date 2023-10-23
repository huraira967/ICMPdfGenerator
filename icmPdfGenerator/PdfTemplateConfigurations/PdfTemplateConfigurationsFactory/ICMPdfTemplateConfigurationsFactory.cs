namespace ICMPdfGenerator.TemplateConfigurations.PdfTemplateConfigurationsFactory
{
    public class ICMPdfTemplateConfigurationsFactory : IPdfTemplateConfigurationsFactory
    {
        public T GetConfiguration<T>() where T : IPdfTemplateConfiguration, new()
        {
            return new T();
        }
    }
}
