using iText.Layout.Element;

namespace ICMPdfGenerator.Brokers.PdfBroker
{
    public partial interface IPdfBroker
    {
        void AddCell(Cell cell);
        void AddImage(Image image);
        void AddLineSeparator(LineSeparator line);
        void AddParagraph(Paragraph paragraph);
        void AddTable(Table table);
        void AddPageBreak();
        string GetDocument();
    }
}
