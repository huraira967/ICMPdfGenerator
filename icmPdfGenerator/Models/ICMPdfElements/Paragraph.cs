using ICMPdfGenerator.ICMProperties.Enums;
using ICMPdfGenerator.Models.ICMPdfElements.CellElements;
using ICMPdfGenerator.Models.ICMPdfLayout.Elements;

namespace ICMPdfGenerator.Models.ICMPdfElements
{
    public class Paragraph : ICellElement
    {
        private List<TextSegment> Text { get; set; }
        private TextAlignment TextAlignment { get; set; }
        public Style Styles { get; set; } = new Style();
        public Paragraph()
        {
            Text = new List<TextSegment>();
        }
        public Paragraph Add(TextSegment textSegment)
        {
            Text.Add(textSegment);
            return this;
        }
        public Paragraph SetTextAlignemnt(TextAlignment textAlignment)
        {
            TextAlignment = textAlignment;
            return this;
        }
        public TextAlignment GetTextAlignment() => TextAlignment;
        public List<TextSegment> GetParagraphSegments() => Text;
    }
}
