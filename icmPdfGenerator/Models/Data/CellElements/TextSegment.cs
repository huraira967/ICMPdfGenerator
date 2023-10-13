using ICMPdfGenerator.Configuration.Enums;

namespace ICMPdfGenerator.Models.Data.CellElements
{
    public class TextSegment
    {
        public string Value { get; set; }
        public Color Color { get; set; }
        public FontSize FontSize { get; set; }
        public FontStyle FontStyle { get; set; }
        public string FontFamily { get; set; }
        public FontWeight FontWeight { get; set; }
        public int letterSpacing { get; set; }
        public VerticalAlignment VeritcalAlignment { get; set; }
        public HorizontalAlignment HorizontalAlignment { get; set; }
        public TextSegment(string value) {
        this.Value = value;
        }
    }
}
