namespace ICMPdfGenerator.TemplateConfigurations.TemplateConfigurationsFactory
{
    public interface ITemplateConfigurationsFactory
    {
        T GetConfiguration<T>() where T : ITemplateConfiguration, new();
    }
}
