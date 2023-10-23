namespace ICMPdfGenerator.Models.ICMPdfLayout.Elements
{
    public partial class Margin
    {
        public float MarginLeft { get; set; }
        public Margin SetMarginLeft(float marginLeft)
        {
            MarginLeft = marginLeft;
            return this;
        }
        public float GetMarginLeft() => MarginLeft;

    }
}
