using iText.Layout.Element;

namespace ICMPdfGenerator.Brokers.PdfBroker
{
    public partial class Itext7PdfBroker
    {
        public void AddTable(Table table)
        {
            Document.Add(table);
        }
        public void AddTable(ICMPdfGenerator.Models.Data.Table table)
        {
           table.Add(new ICMPdfGenerator.Models.Data.Cell());
           var t = mapper.MapToTable(table);
           Document.Add(t);
        }
    }
}
