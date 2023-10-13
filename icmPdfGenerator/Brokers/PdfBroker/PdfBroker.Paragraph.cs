using iText.Layout.Element;

namespace ICMPdfGenerator.Brokers.PdfBroker
{
    public partial class PdfBroker
    {
        public void AddParagraph(Paragraph paragraph)
        {
            Document.Add(paragraph);
        }
    }
}
