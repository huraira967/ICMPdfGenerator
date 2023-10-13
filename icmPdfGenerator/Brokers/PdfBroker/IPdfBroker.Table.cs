using iText.Layout.Element;

namespace ICMPdfGenerator.Brokers.PdfBroker
{
    public partial interface IPdfBroker
    {
        public void AddTable(Table table);
    }
}
