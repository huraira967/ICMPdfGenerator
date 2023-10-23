

using ICMPdfGenerator.ICMProperties.Enums;

namespace ICMPdfGenerator.Models.ICMPdfLayout.Elements
{
    public partial class Border
    {
        private float BorderLeft { get; set; }
        private Color BorderColorLeft { get; set; }
        private UnitValue? BorderRadiusTopRight { get; set; }
        private BorderType _BorderTypeLeft { get; set; }
        private float _OpacityLeft { get; set; } = 1;
        public Border SetBorderLeft(float borderLeft, Color borderLeftColor = Color.BLACK, UnitValue? borderRadiusLeft = null,
                    BorderType borderTypeLeft = BorderType.Solid, float borderOpacityLeft = 1)
        {
            this.BorderLeft = borderLeft;
            this.BorderColorLeft = borderLeftColor;
            this.BorderRadiusTopRight = borderRadiusLeft == null ? new UnitValue(1, false, true) : borderRadiusLeft;
            this._OpacityLeft = borderOpacityLeft;
            this._BorderTypeLeft = borderTypeLeft;
            return this;
        }
        public float GetBorderLeft() => this.BorderLeft;
        public Color GetBorderColorLeft() => this.BorderColorLeft;
        public UnitValue? GetBorderRadiusTopRight() => this.BorderRadiusTopRight;
        public BorderType GetBorderTypeLeft() => this._BorderTypeLeft;
        public float GetBorderOpacityLeft() => this._OpacityLeft;

    }
}
