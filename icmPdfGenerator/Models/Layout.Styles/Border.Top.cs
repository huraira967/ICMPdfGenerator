using ICMPdfGenerator.Configuration.Enums;

namespace ICMPdfGenerator.Models.Layout.Styles
{
    public partial class Border
    {
        private float BorderTop { get; set; }
        private Color BorderTopColor { get; set; }
        private Border SetBorderTop(float borderTop, Color borderTopColor = Color.BLACK)
        {
            this.BorderTop = borderTop;
            this.BorderTopColor = borderTopColor;
            return this;
        }
        private float GetBorderTop() => this.BorderTop;

    }
}
