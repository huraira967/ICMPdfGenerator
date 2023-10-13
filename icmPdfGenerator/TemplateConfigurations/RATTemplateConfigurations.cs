using ICMPdfGenerator.Configuration.Constants;
using ICMPdfGenerator.Configuration.Enums;
using ICMPdfGenerator.Models.Layout.Styles;

namespace ICMPdfGenerator.TemplateConfigurations
{
    public class RATTemplateConfigurations : ITemplateConfiguration
    {
        public string DocumentPath { get; set; }
        public int ModuleId { get; set; } = (int)ICMModules.RAT;
        public string ModuleName { get; set; } = "Resident Assessment Tool";
        public string ModuleVersion { get; set; } = "v1";
        public bool LocalSave { get; set; } = true;
        public bool RemoteSave { get; set; } = true;
        public PageSize PageSize { get; set; } = PageSize.A4;
        public Margin DocumentMargin { get; set; } = new Margin(20f);
        public string FontFamily { get; set; } = ICMPdfGenerator.Configuration.Constants.FontFamily.HELVETICA;
        public Padding DocumentPadding { get; set; } = new Padding(5f);
        public Color Color { get; set; } = Color.GRAY;
    }
}
