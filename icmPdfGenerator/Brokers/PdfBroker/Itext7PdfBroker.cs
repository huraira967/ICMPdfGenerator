using ICMPdfGenerator.Mapper;
using ICMPdfGenerator.TemplateConfigurations;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Hyphenation;
using iText.Layout.Properties;

namespace ICMPdfGenerator.Brokers.PdfBroker
{
    public partial class Itext7PdfBroker : IItext7PdfBroker, IDisposable//iText7Broker change name
    {
        private readonly IItext7Mapper mapper;
        private ITemplateConfiguration TemplateConfiguration { get; set; }

        private PdfDocument PdfDocument { get; set; }
        private Document Document { get; set; }
        private PdfWriter PdfWriter { get; set; }
        private PdfReader PdfReader { get; set; }
        
        private FileStream PdfFileStream { get; set; }
        private PageSize PageSize { get; set; } = PageSize.A4;
        private string PdfFilePath { get; set; }
        private string ModuleName { get; set; }

        public Itext7PdfBroker(ITemplateConfiguration templateConfigurations, IItext7Mapper mapper)
        {
            this.TemplateConfiguration = templateConfigurations;
            this.mapper = mapper;
            SetUpDocument();

            Cell cell = new Cell();
            cell.Add(new Paragraph(""));
            cell.Add(new Table(4));
            cell.AddStyle(new Style());
            var style = new Style();
            
            PdfFont pdfFont = iText.Kernel.Font.PdfFontFactory.CreateFont(StandardFonts.ZAPFDINGBATS);
            
                
        }

        private void SetUpDocument()
        {
            this.PageSize = mapper.MapToPageSize(TemplateConfiguration.PageSize);
            this.PdfFilePath = TemplateConfiguration.DocumentPath;
            this.ModuleName = TemplateConfiguration.ModuleName;
            var margin = mapper.MapToMargin(TemplateConfiguration.DocumentMargin);
            this.PdfFileStream = new FileStream(PdfFilePath, FileMode.Create, FileAccess.Write);
            PdfWriter = new PdfWriter(PdfFileStream);
            PdfDocument = new PdfDocument(PdfWriter);
            Document = new Document(PdfDocument,this.PageSize);
            
            Document.SetMargins(margin.GetMarginTop(), margin.GetMarginRight(), margin.GetMarginBottom(), margin.GetMarginLeft());
            Document.SetBackgroundColor(mapper.MapToColor(TemplateConfiguration.Color));
    
        }
        public string GetDocument()
        {
            return this.PdfFilePath;
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
