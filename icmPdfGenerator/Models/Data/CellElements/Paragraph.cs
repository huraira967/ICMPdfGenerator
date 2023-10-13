using ICMPdfGenerator.Configuration.Enums;

namespace ICMPdfGenerator.Models.Data.CellElements
{
    public class Paragraph : ICellElement
    {
        private List<TextSegment> Text { get; set; }
        private TextAlignment TextAlignment { get; set; }
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
            this.TextAlignment = textAlignment;
            return this;
        }
        public TextAlignment GetTextAlignment() => TextAlignment;
        public List<TextSegment> GetParagraphSegments() => this.Text;
    }
}
