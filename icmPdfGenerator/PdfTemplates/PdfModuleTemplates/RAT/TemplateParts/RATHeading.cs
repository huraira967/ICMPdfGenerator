using ICMPdfGenerator.ICMProperties.Enums;
using ICMPdfGenerator.Models.ICMPdfElements;
using ICMPdfGenerator.Models.ICMPdfElements.CellElements;

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
            // text.FontSize = ICMProperties.Enums.FontSize.Px14;
            // text.FontStyle = ICMProperties.Enums.FontStyle.Bold;
            text.FontWeight = ICMProperties.Enums.FontWeight.MEDIUM;
            //text.HorizontalAlignment = ICMProperties.Enums.HorizontalAlignment.CENTER;
            Heading = new Paragraph().Add(text);
            //Heading.SetTextAlignemnt(ICMProperties.Enums.TextAlignment.CENTER);

            text.Styles.FontSize = FontSize.Px14;
            text.Styles.FontStyle = FontStyle.Bold;
            text.Styles.HorizontalAlignment = HorizontalAlignment.CENTER;
            Heading.Styles.TextAlignment = TextAlignment.CENTER;
        }
        public Paragraph GetHeading() => Heading;
    }
}
