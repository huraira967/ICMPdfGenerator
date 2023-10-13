using iText.Layout.Element;

namespace ICMPdfGenerator.Brokers.PdfBroker
{
    public partial class PdfBroker 
    {
        public void AddTable(Table table)
        {
            Document.Add(table);
        }
    }
}
