using ICMPdfGenerator.ICMProperties.Enums;

namespace ICMPdfGenerator.Models.ICMPdfLayout.Elements
{
    public class Line
    {
        public float LineWidth { get; set; }
        public LineType LineType { get; set; }
        public Color LineColor { get; set; }
        public float Gap { get; set; }
        public Line(LineType lineType, Color lineColor = Color.BLACK, float lineWidth = 1, float gap = 1)
        {
            LineType = lineType;
            LineColor = lineColor;
            LineWidth = lineWidth;
            Gap = gap;
        }
    }
}
