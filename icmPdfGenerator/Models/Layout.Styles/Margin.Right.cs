namespace ICMPdfGenerator.Models.Layout.Styles
{
    public partial class Margin
    {
        public float MarginRight { get; set; }
        public Margin SetMarginRight(float marginRight)
        {
            MarginRight = marginRight;
            return this;
        }
        public float GetMarginRight() => MarginRight;

    }
}
