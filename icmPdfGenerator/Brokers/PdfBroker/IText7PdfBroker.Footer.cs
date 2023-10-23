using iText.Kernel.Colors;
using iText.Kernel.Events;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;


namespace ICMPdfGenerator.Brokers.PdfBroker
{
    public partial class IText7PdfBroker
    {
        private void AddFooter(IBlockElement element, string when = PdfDocumentEvent.END_PAGE)
        {
            var eventHanler = new FooterEventHandler(element);
            PdfDocument.AddEventHandler(when, eventHanler);
        }
    }
    public class FooterEventHandler : iText.Kernel.Events.IEventHandler
    {
        public IBlockElement FooterElement { get; set; }
        public FooterEventHandler(IBlockElement footerElement)
        {
            FooterElement = footerElement;
        }
        public void HandleEvent(Event @event)
        {
            PdfDocumentEvent currentEvent = (PdfDocumentEvent)@event;

            PdfDocument pdfDocument = currentEvent.GetDocument();
            PdfPage currentPage = currentEvent.GetPage();

            PdfCanvas pdfCanvas = new PdfCanvas(currentPage.NewContentStreamBefore(), currentPage.GetResources(), pdfDocument);
            float margin = 10f;
            float y = margin;


            UnitValue width = new UnitValue(UnitValue.POINT, pdfDocument.GetDefaultPageSize().GetWidth() - 2 * margin);
            UnitValue height = UnitValue.CreatePointValue(15);


            //to set background color
            pdfCanvas.SaveState()
                .SetFillColor(DeviceGray.WHITE)
                .Rectangle(margin, y, width.GetValue(), height.GetValue())
                .Fill()
                .RestoreState();

            new Canvas(currentPage, new iText.Kernel.Geom.Rectangle(margin, y, width.GetValue(), height.GetValue()))
                .Add(FooterElement);

            pdfCanvas.Release();
        }

    }
}
