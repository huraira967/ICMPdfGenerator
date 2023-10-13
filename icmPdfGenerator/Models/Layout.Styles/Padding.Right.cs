namespace ICMPdfGenerator.Models.Layout.Styles
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
