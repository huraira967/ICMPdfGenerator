using ICMPdfGenerator.Models.ICMPdfElements;
using ICMPdfGenerator.Models.ICMPdfElements.CellElements;
using ICMPdfGenerator.Models.ICMPdfLayout.Elements;
using iText.Kernel.Colors;
using iText.Kernel.Geom;


namespace ICMPdfGenerator.Mapper
{
    public interface IPdfMapper //change name PdfAdapter
    {
        public object MapToPageSize<TResult>(ICMPdfGenerator.ICMProperties.Enums.PageSize PageSize);
        public object MapToBorder<TResult>(ICMPdfGenerator.Models.ICMPdfLayout.Elements.Border Border);
        public object MapToColor<TResult>(ICMPdfGenerator.ICMProperties.Enums.Color Color);
        public object MapToTable<TResult>(ICMPdfGenerator.Models.ICMPdfElements.Table table);
        public object MapToCell<TResult>(ICMPdfGenerator.Models.ICMPdfElements.Cell cell);
        public object MapToParagraph<TResult>(Paragraph paragraph);
        public object MapToLineSeparator<TResult>(LineSeparator lineSeparator);
        public object MapToImage<TResult>(Image image);
        public object MapToBlockElement<TResult>(ICellElement cellElement);
        public object MapToVerticalSpace<TResult>(float points);
    }
}
