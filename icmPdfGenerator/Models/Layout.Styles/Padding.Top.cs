namespace ICMPdfGenerator.Models.Layout.Styles
{
    public partial class Padding
    {
        public float PaddingTop { get; set; }
        public Padding SetPaddingTop(float paddingTop)
        {
            this.PaddingTop = paddingTop;
            return this;
        }
        public float GetPaddingTop() => this.PaddingTop;

    }
}
