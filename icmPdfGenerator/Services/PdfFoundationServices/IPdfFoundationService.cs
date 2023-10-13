
using ICMPdfGenerator.Models.Data;
using ICMPdfGenerator.Models.Data.CellElements;

namespace ICMPdfGenerator.Services.PdfFoundationService
{
    public interface IPdfFoundationService
    {
        void AddTable(Table table);
        void AddParagraph(Paragraph paragraph);
    }
}
