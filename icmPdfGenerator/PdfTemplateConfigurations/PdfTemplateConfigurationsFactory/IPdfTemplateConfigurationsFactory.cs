namespace ICMPdfGenerator.TemplateConfigurations.PdfTemplateConfigurationsFactory
{
    public interface IPdfTemplateConfigurationsFactory
    {
        T GetConfiguration<T>() where T : IPdfTemplateConfiguration, new();
    }
}
