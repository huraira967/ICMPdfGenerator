using ICMPdfGenerator.Mapper;
using ICMPdfGenerator.PdfTemplateConfigurations;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace ICMPdfGenerator.Brokers.PdfBroker
{
    public partial class IText7PdfBroker : IPdfBroker, IDisposable//iText7Broker change name
    {
        private readonly IPdfMapper mapper;
        private IPdfTemplateConfiguration TemplateConfiguration { get; set; }

        private PdfDocument PdfDocument { get; set; }
        private Document Document { get; set; }
        private PdfWriter PdfWriter { get; set; }
        private PdfReader PdfReader { get; set; }

        private FileStream PdfFileStream { get; set; }
        private PageSize PageSize { get; set; } = PageSize.A4;
        private string PdfFilePath { get; set; }
        private string ModuleName { get; set; }

        public IText7PdfBroker(IPdfTemplateConfiguration templateConfigurations,
                               IPdfMapper mapper)
        {
            this.TemplateConfiguration = templateConfigurations;
            this.mapper = mapper;
            SetUpDocument();



        }

        private void SetUpDocument()
        {
            this.PageSize = mapper.MapToPageSize(TemplateConfiguration.PageSize);
            this.PdfFilePath = TemplateConfiguration.DocumentPath;
            this.ModuleName = TemplateConfiguration.ModuleName;
            var margin = TemplateConfiguration.DocumentMargin;
            this.PdfFileStream = new FileStream(PdfFilePath, FileMode.Create, FileAccess.Write);
            PdfWriter = new PdfWriter(PdfFileStream);
            PdfDocument = new PdfDocument(PdfWriter);
            Document = new Document(PdfDocument, this.PageSize);

            Document.SetMargins(margin.GetMarginTop(), margin.GetMarginRight(), margin.GetMarginBottom(), margin.GetMarginLeft());
            Document.SetBackgroundColor(mapper.MapToColor(TemplateConfiguration.Color));
            if (TemplateConfiguration.Footer != null)
            {
                var footer = mapper.MapToBlockElement(TemplateConfiguration.Footer);
                AddFooter(footer);
            }
        }

        public void AddTable(Table table)
        {
            Document.Add(table);
        }
        public void AddParagraph(Paragraph paragraph)
        {
            Document.Add(paragraph);
        }
        public void AddLineSeparator(LineSeparator lineSepartor)
        {
            Document.Add(lineSepartor);
        }
        public void AddImage(Image image)
        {
            Document.Add(image);
        }
        public void AddCell(Cell cell)
        {
            Document.Add(cell);
        }
        public void AddPageBreak()
        {
            AreaBreak areaBreak = new();
            Document.Add(areaBreak);
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
