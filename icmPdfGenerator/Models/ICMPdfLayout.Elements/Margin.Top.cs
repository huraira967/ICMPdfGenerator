namespace ICMPdfGenerator.Models.ICMPdfLayout.Elements
{
    public partial class Margin
    {
        public float MarginTop { get; set; }
        public Margin SetMarginTop(float marginTop)
        {
            MarginTop = marginTop;
            return this;
        }
        public float GetMarginTop() => MarginTop;
    }
}
