using ICMPdfGenerator.Mapper;
using ICMPdfGenerator.Brokers.PdfBroker;
using ICMPdfGenerator.Models.Data;

namespace ICMPdfGenerator.Services.PdfFoundationService
{
    public class PdfFoundationService : IPdfFoundationService
    {
        private readonly IItext7PdfBroker pdfBroker;
        private readonly IItext7Mapper iTextMapper;

        public PdfFoundationService(IItext7PdfBroker pdfBroker, IItext7Mapper pdfAdapeter)
        {
            this.pdfBroker = pdfBroker;
            this.iTextMapper = pdfAdapeter;
        }

        public void AddCell(Cell cell)
        {
           var iText7Cell = iTextMapper.MapToCell(cell);
            pdfBroker.AddCell(iText7Cell);
        }

        public void AddParagraph(ICMPdfGenerator.Models.Data.CellElements.Paragraph paragraph)
        {
            var convertedParagraph = iTextMapper.MapToParagraph(paragraph);
            this.pdfBroker.AddParagraph(convertedParagraph);
        }

        public void AddTable(ICMPdfGenerator.Models.Data.Table table)
        {
            //which is more dangerous place 
            //foundationService Or Broker
            //when Library changes broker implementation changes but adding column is not library specific task
           // table.Add(new ICMPdfGenerator.Models.Data.Cell());
            var convertedTable = iTextMapper.MapToTable(table);

            this.pdfBroker.AddTable(convertedTable);
        }

        public string GetDocumentPath()
        {
          return  this.pdfBroker.GetDocument();
        }
    }
}
