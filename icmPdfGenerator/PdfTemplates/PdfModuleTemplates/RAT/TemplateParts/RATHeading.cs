﻿using ICMPdfGenerator.Configuration.Enums;
using ICMPdfGenerator.Models.Data.CellElements;

namespace ICMPdfGenerator.PdfTemplates.PdfModuleTemplates.RAT.TemplateParts
{
    public class RATHeading : IRATTemplatePart
    {
        private Paragraph Heading { get; set; }
        public string DocumentTitle { get; set; }

        public RATHeading(string heading)
        {
            this.DocumentTitle = heading;

            var text = new TextSegment(DocumentTitle);
           // text.FontSize = Configuration.Enums.FontSize.Px14;
           // text.FontStyle = Configuration.Enums.FontStyle.Bold;
            text.FontWeight = Configuration.Enums.FontWeight.MEDIUM;
            //text.HorizontalAlignment = Configuration.Enums.HorizontalAlignment.CENTER;
            Heading = new Paragraph().Add(text);
            //Heading.SetTextAlignemnt(Configuration.Enums.TextAlignment.CENTER);

            text.Styles.FontSize = FontSize.Px14;
            text.Styles.FontStyle = FontStyle.Bold;
            text.Styles.HorizontalAlignment = HorizontalAlignment.CENTER;
            Heading.Styles.TextAlignment = TextAlignment.CENTER;
        }
        public Paragraph GetHeading() => Heading;
    }
}
