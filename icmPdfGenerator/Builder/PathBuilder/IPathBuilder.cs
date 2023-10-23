using ICMPdfGenerator.Models.Builder;

namespace ICMPdfGenerator.Builder.documentPathBuilder
{
    public interface IPathBuilder
    {
        string BuildPath(DocumentPathAttributes PdfDocumentPath);
    }
}
