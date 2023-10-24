using ICMPdfGenerator.Brokers.PdfBroker;
using ICMPdfGenerator.Mapper;
using ICMPdfGenerator.Models.ICMPdfElements;
using ICMPdfGenerator.Models.ICMPdfLayout.Elements;

namespace ICMPdfGenerator.Services.PdfFoundationService
{
    public class IText7PdfFoundationService : IIText7PdfFoundationService
    {
        private readonly IPdfBroker iText7PdfBroker;
        private readonly IPdfMapper iText7Mapper;

        public IText7PdfFoundationService(IPdfBroker itext7PdfBroker, IPdfMapper itext7Mapper)
        {
            this.iText7PdfBroker = itext7PdfBroker;
            this.iText7Mapper = itext7Mapper;
        }

        public void AddCell(Cell cell)
        {
            var iText7Cell = (iText.Layout.Element.Cell)iText7Mapper.MapToCell<iText.Layout.Element.Cell>(cell);
            iText7PdfBroker.AddCell(iText7Cell);
        }

        public void AddImage(Image image)
        {
            var iText7Image = (iText.Layout.Element.Image)iText7Mapper.MapToImage<iText.Layout.Element.Image>(image);
            iText7PdfBroker.AddImage(iText7Image);
        }

        public void AddLineSeparator(LineSeparator lineSeparator)
        {
            var iText7LineSeparator = (iText.Layout.Element.LineSeparator)iText7Mapper.MapToLineSeparator<iText.Layout.Element.LineSeparator>(lineSeparator);
            iText7PdfBroker.AddLineSeparator(iText7LineSeparator);
        }

        public void AddPageBreak()
        {
            iText7PdfBroker.AddPageBreak();
        }

        public void AddParagraph(Paragraph paragraph)
        {
            var convertedParagraph = (iText.Layout.Element.Paragraph)iText7Mapper.MapToParagraph<iText.Layout.Element.Paragraph>(paragraph);
            this.iText7PdfBroker.AddParagraph(convertedParagraph);
        }

        public void AddSpace(float space)
        {
            var iText7TableSpace = (iText.Layout.Element.Table)iText7Mapper.MapToVerticalSpace<iText.Layout.Element.Table>(space);
            iText7PdfBroker.AddTable(iText7TableSpace);
        }

        public void AddTable(ICMPdfGenerator.Models.ICMPdfElements.Table table)
        {
            var convertedTable = (iText.Layout.Element.Table)iText7Mapper.MapToTable<iText.Layout.Element.Table>(table);

            this.iText7PdfBroker.AddTable(convertedTable);
        }

        public string GetDocumentPath()
        {
            return this.iText7PdfBroker.GetDocument();
        }
    }
}
