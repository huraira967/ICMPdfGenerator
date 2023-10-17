using iText.Layout.Element;

namespace ICMPdfGenerator.Brokers.PdfBroker
{
    public partial class Itext7PdfBroker
    {
        public void AddParagraph(Paragraph paragraph)
        {
            Document.Add(paragraph);
        }
    }
}
