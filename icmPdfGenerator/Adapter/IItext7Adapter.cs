using ICMPdfGenerator.Models.Data;
using ICMPdfGenerator.Models.Layout.Styles;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Layout.Borders;

namespace ICMPdfGenerator.Adapter
{
    public interface IItext7Adapter
    {
        public PageSize ConvertToPageSize(ICMPdfGenerator.Configuration.Enums.PageSize PageSize);
        public iText.Layout.Borders.Border ConvertToBorder(ICMPdfGenerator.Models.Layout.Styles.Border Border);
        public Color ConvertToColor(ICMPdfGenerator.Configuration.Enums.Color Color);
        public Margin ConvertToMargin(Margin margin);
        public Padding ConvertToPadding(Padding padding);

        public iText.Layout.Element.Table ConvertToTable(ICMPdfGenerator.Models.Data.Table table);
        public iText.Layout.Element.Cell ConvertToCell(ICMPdfGenerator.Models.Data.Cell cell);
        public iText.Layout.Element.Paragraph ConvertToParagraph(ICMPdfGenerator.Models.Data.CellElements.Paragraph paragraph);
    }
}
