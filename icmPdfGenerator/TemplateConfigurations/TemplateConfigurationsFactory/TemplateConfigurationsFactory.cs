namespace ICMPdfGenerator.TemplateConfigurations.TemplateConfigurationsFactory
{
    public class TemplateConfigurationsFactory : ITemplateConfigurationsFactory
    {
        public T GetConfiguration<T>() where T : ITemplateConfiguration, new()
        {
            return new T();
        }
    }
}
