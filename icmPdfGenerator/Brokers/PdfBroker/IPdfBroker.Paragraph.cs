﻿using iText.Layout.Element;

namespace ICMPdfGenerator.Brokers.PdfBroker
{
    public partial interface IPdfBroker
    {
        void AddParagraph(Paragraph paragraph);
    }
}
