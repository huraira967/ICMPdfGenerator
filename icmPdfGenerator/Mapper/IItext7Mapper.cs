using ICMPdfGenerator.Models.Data;
using ICMPdfGenerator.Models.Layout.Styles;
using iText.Kernel.Colors;
using iText.Kernel.Geom;


namespace ICMPdfGenerator.Mapper 
{
    public interface IItext7Mapper //change name PdfAdapter
    {
        public PageSize MapToPageSize(ICMPdfGenerator.Configuration.Enums.PageSize PageSize);
        public iText.Layout.Borders.Border MapToBorder(ICMPdfGenerator.Models.Layout.Styles.Border Border);
        public Color MapToColor(ICMPdfGenerator.Configuration.Enums.Color Color);
        public iText.Layout.Element.Table MapToTable(ICMPdfGenerator.Models.Data.Table table);
        public iText.Layout.Element.Cell MapToCell(ICMPdfGenerator.Models.Data.Cell cell);
        public iText.Layout.Element.Paragraph MapToParagraph(ICMPdfGenerator.Models.Data.CellElements.Paragraph paragraph);
    }
}
