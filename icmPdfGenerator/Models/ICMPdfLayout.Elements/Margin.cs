namespace ICMPdfGenerator.Models.ICMPdfLayout.Elements
{
    public partial class Margin
    {
        public Margin(float margin)
        {
            this.SetMarginLeft(margin);
            this.SetMarginRight(margin);
            this.SetMarginTop(margin);
            this.SetMarginBottom(margin);
        }
        public Margin GetMargin() => this;
    }
}
