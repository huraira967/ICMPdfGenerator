namespace ICMPdfGenerator.ICMProperties.Constants
{
    public class PdfDocumentEventName
    {        //
        // Summary:
        //     Dispatched after page is created.
        public const string START_PAGE = "StartPdfPage";

        //
        // Summary:
        //     Dispatched after page is inserted/added into a document.
        public const string INSERT_PAGE = "InsertPdfPage";

        //
        // Summary:
        //     Dispatched after page is removed from a document.
        public const string REMOVE_PAGE = "RemovePdfPage";

        //
        // Summary:
        //     Dispatched before page is flushed to a document.
        //
        // Remarks:
        //     Dispatched before page is flushed to a document. This event isn't necessarily
        //     dispatched when a successive page has been created. Keep it in mind when using
        //     with highlevel iText API.
        public const string END_PAGE = "EndPdfPage";

    }
}
