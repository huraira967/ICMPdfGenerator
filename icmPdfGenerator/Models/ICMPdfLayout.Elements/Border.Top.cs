using ICMPdfGenerator.ICMProperties.Enums;

namespace ICMPdfGenerator.Models.ICMPdfLayout.Elements
{
    public partial class Border
    {
        private float BorderTop { get; set; }
        private Color BorderColorTop { get; set; }
        private UnitValue? BorderRadiusTopLeft { get; set; }
        private BorderType _BorderTypeTop { get; set; }
        private float _OpacityTop { get; set; } = 1;
        public Border SetBorderTop(float borderTop, Color borderTopColor = Color.BLACK, UnitValue? borderRadiusTop = null,
                        BorderType borderTypeTop = BorderType.Solid, float borderOpacityTop = 1)
        {
            this.BorderTop = borderTop;
            this.BorderColorTop = borderTopColor;
            this.BorderRadiusTopLeft = borderRadiusTop == null ? new UnitValue(1, false, true) : borderRadiusTop;
            this._BorderTypeTop = borderTypeTop;
            this._OpacityTop = borderOpacityTop;
            return this;
        }
        public float GetBorderTop() => this.BorderTop;
        public Color GetBorderColorTop() => this.BorderColorTop;
        public UnitValue? GetBorderRadiusTopLeft() => this.BorderRadiusTopLeft;
        public BorderType GetBorderTypeTop() => this._BorderTypeTop;
        public float GetBorderOpacityTop() => this._OpacityTop;

    }
}
