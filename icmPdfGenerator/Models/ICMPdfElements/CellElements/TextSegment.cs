using ICMPdfGenerator.ICMProperties.Enums;
using ICMPdfGenerator.Models.ICMPdfLayout.Elements;

namespace ICMPdfGenerator.Models.ICMPdfElements.CellElements
{
    public class TextSegment
    {
        public string Value { get; set; }
        public Color Color { get; set; } = Color.BLACK;
        public FontSize FontSize { get; set; } = FontSize.Px6;
        public FontStyle FontStyle { get; set; } = FontStyle.Nomral;
        public string FontFamily { get; set; } = ICMPdfGenerator.ICMProperties.Constants.FontFamily.HELVETICA;
        public FontWeight FontWeight { get; set; } = FontWeight.NORMAL;
        public int letterSpacing { get; set; }
        public VerticalAlignment VeritcalAlignment { get; set; } = VerticalAlignment.MIDDLE;
        public HorizontalAlignment HorizontalAlignment { get; set; } = HorizontalAlignment.LEFT;
        public Style Styles { get; set; } = new Style();

        public TextSegment(string value)
        {
            this.Value = value;
        }
    }
}
