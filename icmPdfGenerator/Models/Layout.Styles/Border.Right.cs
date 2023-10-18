using ICMPdfGenerator.Configuration.Enums;

namespace ICMPdfGenerator.Models.Layout.Styles
{
    public partial class Border
    {
        private float BorderRight { get; set; }
        private Color BorderColorRight { get; set; }
        private UnitValue? BorderRadiusBottomRight { get; set; }
        private BorderType _BorderTypeRight { get; set; }
        private float _OpacityRight { get; set; } = 1;
        public Border SetBorderRight(float borderRight, Color borderRightColor = Color.BLACK, UnitValue? borderRadiusRight = null,
                        BorderType borderTypeRight = BorderType.Solid, float borderOpacityRight = 1)
        {
            this.BorderRight = borderRight;
            this.BorderColorRight = borderRightColor;
            this.BorderRadiusBottomRight = borderRadiusRight == null ? new UnitValue(1, false, true) : borderRadiusRight;
            this._BorderTypeRight = borderTypeRight;
            this._OpacityRight = borderOpacityRight;
            return this;
        }
        public float GetBorderRight() => this.BorderRight;
        public Color GetBorderColorRight() => this.BorderColorRight;
        public UnitValue? GetBorderRadiusBottomRight() => this.BorderRadiusBottomRight;
        public BorderType GetBorderTypeRight() => this._BorderTypeRight;
        public float GetBorderOpacityRight() => this._OpacityRight;

    }
}
