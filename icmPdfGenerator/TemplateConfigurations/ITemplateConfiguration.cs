using ICMPdfGenerator.Configuration.Constants;
using ICMPdfGenerator.Configuration.Enums;
using ICMPdfGenerator.Models.Layout.Styles;

namespace ICMPdfGenerator.TemplateConfigurations
{
    public interface ITemplateConfiguration
    {
        //Module Specific
        string DocumentPath { get; set; }
        int ModuleId { get; set; }
        string ModuleName { get; set; }
        string ModuleVersion { get; set; }

        //Save Options
        bool LocalSave { get; set; }
        bool RemoteSave { get; set; }

        //Document  
        PageSize PageSize { get; set; }
        Margin DocumentMargin { get; set; }
        string FontFamily { get; set; }
        Padding DocumentPadding { get; set; }
        Color Color { get; set; }
    }
}
