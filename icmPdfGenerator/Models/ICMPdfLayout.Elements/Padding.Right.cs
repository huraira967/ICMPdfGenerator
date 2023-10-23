namespace ICMPdfGenerator.Models.ICMPdfLayout.Elements
{
    public partial class Padding
    {
        public float PaddingRight { get; set; }
        public Padding SetPaddingRight(float paddingRight)
        {
            this.PaddingRight = paddingRight;
            return this;
        }
        public float GetPaddingRight() => this.PaddingRight;

    }
}
