using ICMPdfGenerator.Models.Builder;

namespace ICMPdfGenerator.Builder.documentPathBuilder
{
    public class PdfDocumentPathBuilder : IPathBuilder
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private string ServerPath { get; set; }

        public PdfDocumentPathBuilder(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
            SetUpServerPath();
        }
        private void SetUpServerPath()
        {
            this.ServerPath = webHostEnvironment.ContentRootPath;
        }
        public string BuildPath(DocumentPathAttributes pdfDocumentPath)
        {
            return CreatePdfFileName(pdfDocumentPath);
        }
        private string CreatePdfFileName(DocumentPathAttributes PdfDocumentPath)
        {
            return $@"{EnsureFolderExsists(PdfDocumentPath)}\T{DateTimeOffset.Now.ToUnixTimeMilliseconds()}M{PdfDocumentPath.ModuleId}D{PdfDocumentPath.DocumentId}F{PdfDocumentPath.FacilityId}U{PdfDocumentPath.UserId}.pdf";
        }
        private string EnsureFolderExsists(DocumentPathAttributes pdfDocumentPath)
        {
            string folderPath = GetDocumentFolderPath(pdfDocumentPath.DocumentFolderName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            return folderPath;
        }
        private string GetDocumentFolderPath(string DocumentFolderName)
        {
            return @$"{this.ServerPath}\{DocumentFolderName}";
        }
    }
}
