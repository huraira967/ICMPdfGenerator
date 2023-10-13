namespace ICMPdfGenerator.Models.Layout.Styles
{
    public partial class Margin
    {
        public float MarginBottom { get; set; }
        public Margin SetMarginBottom(float marginBottom)
        {
            this.MarginBottom = marginBottom;
            return this;
        }
        public float GetMarginBottom() => this.MarginBottom;

    }
}
