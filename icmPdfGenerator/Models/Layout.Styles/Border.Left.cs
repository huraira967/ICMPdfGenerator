

using ICMPdfGenerator.Configuration.Enums;

namespace ICMPdfGenerator.Models.Layout.Styles
{
    public partial class Border
    {
        private float BorderLeft { get; set; }
        private Color BorderLeftColor { get; set; }
        private Border SetBorderLeft(float borderLeft, Color borderLeftColor = Color.BLACK) 
        {
            this.BorderLeft = borderLeft;
            this.BorderLeftColor = borderLeftColor;
            return this;
        }
        private float GetBorderLeft() => this.BorderLeft;

    }
}
