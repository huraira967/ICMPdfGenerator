using ICMPdfGenerator.Models.Builder;

namespace ICMPdfGenerator.Builder.documentPathBuilder
{
    public class PdfDocumentPathBuilder : IPdfDocumentPathBuilder
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
        public string GetDocumentPath(PdfDocumentPath pdfDocumentPath)
        {
            return CreatePdfFileName(pdfDocumentPath);
        }
        private string CreatePdfFileName(PdfDocumentPath PdfDocumentPath)
        {
            return $@"{EnsureFolderExsists(PdfDocumentPath)}\T{DateTimeOffset.Now.ToUnixTimeMilliseconds()}M{PdfDocumentPath.ModuleId}D{PdfDocumentPath.DocumentId}F{PdfDocumentPath.FacilityId}U{PdfDocumentPath.UserId}.pdf";
        }
        private string EnsureFolderExsists(PdfDocumentPath pdfDocumentPath)
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
