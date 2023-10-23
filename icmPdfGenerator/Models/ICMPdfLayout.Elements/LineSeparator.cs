namespace ICMPdfGenerator.Models.ICMPdfLayout.Elements
{
    public class LineSeparator
    {
        public Line Line { get; }
        public Style Styles { get; set; } = new Style();
        public LineSeparator(Line line)
        {
            Line = line;
        }

    }
}
