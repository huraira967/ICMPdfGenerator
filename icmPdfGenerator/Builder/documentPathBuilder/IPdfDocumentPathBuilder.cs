using ICMPdfGenerator.Models.Builder;

namespace ICMPdfGenerator.Builder.documentPathBuilder
{
    public interface IPdfDocumentPathBuilder
    {
        string GetDocumentPath(PdfDocumentPath PdfDocumentPath);
    }
}
