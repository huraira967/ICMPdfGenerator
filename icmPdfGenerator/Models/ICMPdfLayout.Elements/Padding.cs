namespace ICMPdfGenerator.Models.ICMPdfLayout.Elements
{
    public partial class Padding
    {
        public Padding()
        {
        }
        public Padding(float padding)
        {
            this.SetPaddingLeft(padding);
            this.SetPaddingRight(padding);
            this.SetPaddingBottom(padding);
            this.SetPaddingTop(padding);
        }
        public Padding GetPadding() => this;

    }
}
