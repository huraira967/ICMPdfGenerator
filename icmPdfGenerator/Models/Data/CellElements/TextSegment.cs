using ICMPdfGenerator.Configuration.Constants;
using ICMPdfGenerator.Configuration.Enums;

namespace ICMPdfGenerator.Models.Data.CellElements
{
    public class TextSegment
    {
        public string Value { get; set; }
        public Color Color { get; set; } = Color.BLACK;
        public FontSize FontSize { get; set; } = FontSize.Px8;
        public FontStyle FontStyle { get; set; } = FontStyle.Nomral;
        public string FontFamily { get; set; } = ICMPdfGenerator.Configuration.Constants.FontFamily.HELVETICA;
        public FontWeight FontWeight { get; set; } = FontWeight.NORMAL;
        public int letterSpacing { get; set; }
        public VerticalAlignment VeritcalAlignment { get; set; } = VerticalAlignment.MIDDLE;
        public HorizontalAlignment HorizontalAlignment { get; set; } = HorizontalAlignment.LEFT;
        public TextSegment(string value) {
        this.Value = value;
        }
    }
}
