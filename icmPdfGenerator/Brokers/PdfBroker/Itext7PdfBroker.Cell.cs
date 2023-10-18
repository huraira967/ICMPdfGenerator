using iText.Layout.Element;

namespace ICMPdfGenerator.Brokers.PdfBroker
{
    public partial class Itext7PdfBroker
    {
        public void AddCell(Cell cell)
        {
            Document.Add(cell);
        }
    }
}
