using ICMPdfGenerator.ICMProperties.Enums;
using ICMPdfGenerator.Models.ICMPdfElements.CellElements;
using ICMPdfGenerator.Models.ICMPdfLayout.Elements;

namespace ICMPdfGenerator.PdfTemplateConfigurations
{
    public class NoPdfTemplateConfigurations : IPdfTemplateConfiguration
    {
        public string DocumentPath { get; set; } = "";
        public int ModuleId { get; set; } = (int)ICMModules.RAT;
        public string ModuleName { get; set; } = "Resident Assessment Tool";
        public string ModuleVersion { get; set; } = "v1";
        public bool LocalSave { get; set; } = true;
        public bool RemoteSave { get; set; } = true;
        public PageSize PageSize { get; set; } = PageSize.A5;
        public Margin DocumentMargin { get; set; } = new Margin(20f);
        public string FontFamily { get; set; } = ICMPdfGenerator.ICMProperties.Constants.FontFamily.HELVETICA;
        public Padding DocumentPadding { get; set; } = new Padding(50f);
        public Color Color { get; set; } = Color.BLUE;
        public ICellElement Footer { get; set; }
    }
}
