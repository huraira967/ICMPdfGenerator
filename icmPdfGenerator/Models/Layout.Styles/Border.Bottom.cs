using ICMPdfGenerator.Configuration.Enums;

namespace ICMPdfGenerator.Models.Layout.Styles
{
    public partial class Border
    {
        private float BorderBottom { get; set; }
        private Color BorderColorBottom { get; set; }
        private UnitValue? BorderRadiusBottomLeft { get; set; }
        private BorderType _BorderTypeBottom { get; set; } 
        private float _OpacityBottom { get; set; } = 1;

        public Border SetBorderBottom(float borderBottom, Color borderBottomColor = Color.BLACK, UnitValue? borderRadiusBottom = null,
            BorderType borderTypeBottom = BorderType.Solid, float borderOpacityBottom = 1)
        {
            this.BorderBottom = borderBottom;
            this.BorderColorBottom = borderBottomColor;
            this.BorderRadiusBottomLeft = borderRadiusBottom == null ? new UnitValue(1, false, true): borderRadiusBottom;
            this._BorderTypeBottom = borderTypeBottom;
            this._OpacityBottom = borderOpacityBottom;
            return this;
        }
        public float GetBorderBottom() => this.BorderBottom;
        public Color GetBorderColorBottom() => this.BorderColorBottom;
        public UnitValue? GetBorderRadiusBottomLeft() => this.BorderRadiusBottomLeft;
        public float GetBorderOpacityBottom() => this._OpacityBottom;
        public BorderType GetBorderTypeBottom() => this._BorderTypeBottom;
    }
}
