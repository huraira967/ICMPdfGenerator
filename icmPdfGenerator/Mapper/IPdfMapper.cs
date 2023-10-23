using ICMPdfGenerator.Models.ICMPdfElements;
using ICMPdfGenerator.Models.ICMPdfElements.CellElements;
using ICMPdfGenerator.Models.ICMPdfLayout.Elements;
using iText.Kernel.Colors;
using iText.Kernel.Geom;


namespace ICMPdfGenerator.Mapper
{
    public interface IPdfMapper //change name PdfAdapter
    {
        public PageSize MapToPageSize(ICMPdfGenerator.ICMProperties.Enums.PageSize PageSize);
        public iText.Layout.Borders.Border MapToBorder(ICMPdfGenerator.Models.ICMPdfLayout.Elements.Border Border);
        public Color MapToColor(ICMPdfGenerator.ICMProperties.Enums.Color Color);
        public iText.Layout.Element.Table MapToTable(ICMPdfGenerator.Models.ICMPdfElements.Table table);
        public iText.Layout.Element.Cell MapToCell(ICMPdfGenerator.Models.ICMPdfElements.Cell cell);
        public iText.Layout.Element.Paragraph MapToParagraph(Paragraph paragraph);
        public iText.Layout.Element.LineSeparator MapToLineSeparator(LineSeparator lineSeparator);
        public iText.Layout.Element.Image MapToImage(Image image);
        public iText.Layout.Element.IBlockElement MapToBlockElement(ICellElement cellElement);
        public iText.Layout.Element.Table MapToVerticalSpace(float points);
    }
}
