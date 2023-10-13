using ICMPdfGenerator.Adapter;
using ICMPdfGenerator.Brokers.PdfBroker;
using ICMPdfGenerator.Models.Data.CellElements;
using System.ComponentModel;

namespace ICMPdfGenerator.Services.PdfFoundationService
{
    public class PdfFoundationService : IPdfFoundationService
    {
        private readonly IPdfBroker pdfBroker;
        private readonly IItext7Adapter pdfAdapeter;

        public PdfFoundationService(IPdfBroker pdfBroker, IItext7Adapter pdfAdapeter)
        {
            this.pdfBroker = pdfBroker;
            this.pdfAdapeter = pdfAdapeter;
        }

        public void AddParagraph(ICMPdfGenerator.Models.Data.CellElements.Paragraph paragraph)
        {
            var convertedParagraph = pdfAdapeter.ConvertToParagraph(paragraph);
            this.pdfBroker.AddParagraph(convertedParagraph);
        }

        public void AddTable(ICMPdfGenerator.Models.Data.Table table)
        {
            var convertedTable = pdfAdapeter.ConvertToTable(table);
            this.pdfBroker.AddTable(convertedTable);
        }

        public string GetDocumentPath()
        {
          return  this.pdfBroker.GetDocument();
        }
    }
}
