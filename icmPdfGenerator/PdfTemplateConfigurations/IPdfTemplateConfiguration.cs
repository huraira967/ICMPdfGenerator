using ICMPdfGenerator.ICMProperties.Enums;
using ICMPdfGenerator.Models.ICMPdfElements.CellElements;
using ICMPdfGenerator.Models.ICMPdfLayout.Elements;

namespace ICMPdfGenerator.PdfTemplateConfigurations
{
    public interface IPdfTemplateConfiguration
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
        ICellElement Footer { get; set; }
    }
}
