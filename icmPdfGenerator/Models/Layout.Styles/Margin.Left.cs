namespace ICMPdfGenerator.Models.Layout.Styles
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
