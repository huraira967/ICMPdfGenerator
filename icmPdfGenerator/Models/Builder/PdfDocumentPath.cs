﻿namespace ICMPdfGenerator.Models.Builder
{
    public class PdfDocumentPath
    {
        public int UserId { get; set; }
        public int FacilityId { get; set; }
        public int ModuleId { get; set; }
        public int DocumentId { get; set; }
        public string DocumentFolderName { get; set; }
        public PdfDocumentPath(int userId, int facilityId, int moduleId, int documentId, string folderName)
        {
            this.UserId = userId;
            this.FacilityId = facilityId;
            this.ModuleId = moduleId;
            this.DocumentId = documentId;
            this.DocumentFolderName = folderName;
        }
    }
}
