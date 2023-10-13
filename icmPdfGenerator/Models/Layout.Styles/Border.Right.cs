using ICMPdfGenerator.Configuration.Enums;

namespace ICMPdfGenerator.Models.Layout.Styles
{
    public partial class Border
    {
        private float BorderRight { get; set; }
        private Color BorderRightColor { get; set; }
        private Border SetBorderRight(float borderRight, Color borderRightColor = Color.BLACK)
        {
            this.BorderRight = borderRight;
            this.BorderRightColor = borderRightColor;
            return this;
        }
        private float GetBorderRight() => this.BorderRight;

    }
}
