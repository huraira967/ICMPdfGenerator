using ICMPdfGenerator.Configuration.Enums;

namespace ICMPdfGenerator.Models.Layout.Styles
{
    public partial class Border
    {
        private float BorderBottom { get; set; }
        private Color BorderColorBottom { get; set; }

        private Border SetBorderBottom(float borderBottom, Color borderBottomColor = Color.BLACK)
        {
            this.BorderBottom = borderBottom;
            this.BorderColorBottom = borderBottomColor;
            return this;
        }
        private float GetBorderBottom() => this.BorderBottom;
    }
}
