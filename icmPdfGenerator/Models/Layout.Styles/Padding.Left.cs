namespace ICMPdfGenerator.Models.Layout.Styles
{
    public partial class Padding
    {
        public float PaddingLeft { get; set; }
        public Padding SetPaddingLeft(float paddingLeft)
        {
            this.PaddingLeft = paddingLeft;
            return this;
        }
        public float GetPaddingLeft() => this.PaddingLeft;
        
    }
}
