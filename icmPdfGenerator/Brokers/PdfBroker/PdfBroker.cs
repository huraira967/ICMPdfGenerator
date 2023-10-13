using ICMPdfGenerator.Adapter;
using ICMPdfGenerator.TemplateConfigurations;
using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Net.Security;

namespace ICMPdfGenerator.Brokers.PdfBroker
{
    public partial class PdfBroker : IPdfBroker, IDisposable
    {
        private readonly IItext7Adapter adapter;
        private ITemplateConfiguration TemplateConfiguration { get; set; }

        private PdfDocument PdfDocument { get; set; }
        private Document Document { get; set; }
        private PdfWriter PdfWriter { get; set; }
        private PdfReader PdfReader { get; set; }
        
        private FileStream PdfFileStream { get; set; }
        private PageSize PageSize { get; set; } = PageSize.A4;
        private string PdfFilePath { get; set; }
        private string ModuleName { get; set; }
        public PdfBroker(ITemplateConfiguration templateConfigurations, IItext7Adapter adapter)
        {
            this.TemplateConfiguration = templateConfigurations;
            this.adapter = adapter;
            SetUpDocument();

            
        }

        private void SetUpDocument()
        {
            this.PageSize = adapter.ConvertToPageSize(TemplateConfiguration.PageSize);
            this.PdfFilePath = TemplateConfiguration.DocumentPath;
            this.ModuleName = TemplateConfiguration.ModuleName;
            var margin = adapter.ConvertToMargin(TemplateConfiguration.DocumentMargin);
            this.PdfFileStream = new FileStream(PdfFilePath, FileMode.Create, FileAccess.Write);
            PdfWriter = new PdfWriter(PdfFileStream);
            PdfDocument = new PdfDocument(PdfWriter);
            Document = new Document(PdfDocument,this.PageSize);
            
            Document.SetMargins(margin.GetMarginTop(), margin.GetMarginRight(), margin.GetMarginBottom(), margin.GetMarginLeft());
            Document.SetBackgroundColor(adapter.ConvertToColor(TemplateConfiguration.Color));
    
        }
        private void FinalizeDocument()
        {
            Document.Close();
            PdfDocument.Close();
        }

        public void Dispose()
        {
            FinalizeDocument();
        }


    }
    
}
