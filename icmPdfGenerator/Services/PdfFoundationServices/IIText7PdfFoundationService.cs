
using ICMPdfGenerator.Models.ICMPdfElements;
using ICMPdfGenerator.Models.ICMPdfLayout.Elements;

namespace ICMPdfGenerator.Services.PdfFoundationService
{
    public interface IIText7PdfFoundationService
    {
        void AddTable(Table table);
        void AddParagraph(Paragraph paragraph);
        void AddCell(Cell cell);
        void AddImage(Image image);
        void AddLineSeparator(LineSeparator lineSeparator);
        void AddSpace(float space);
        void AddPageBreak();
        string GetDocumentPath();
    }
}
