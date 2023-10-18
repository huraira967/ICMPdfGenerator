using ICMPdfGenerator.Configuration.Enums;
using iText.Layout.Borders;
using iText.Layout.Properties;

namespace ICMPdfGenerator.Models.Layout.Styles
{
    public partial class Border
    {
        private BorderType _BorderType { get; set; }
        private float _Opacity { get; set; }
        private float _Border { get; set; }
        private Color Color { get; set; }
        private UnitValue? _BorderRadius { get; set; }
        
        public Border(float border = 1, BorderType borderType = BorderType.Solid, Color color = Color.BLACK, UnitValue? borderRadius = null, float opacity = 1)
        {
            if(borderType == BorderType.None) 
            {
                border = 0;
            }
            this._BorderType =  borderType;
            this.Color = color;
            this._Border = border;
            this._BorderRadius = borderRadius == null ? new UnitValue(1, false, true) : borderRadius;
            this._Opacity = opacity;
            SetBorderBottom(border,color,borderRadius, borderType,opacity);
            SetBorderLeft(border, color, borderRadius, borderType, opacity);
            SetBorderRight(border, color, borderRadius, borderType, opacity);
            SetBorderTop(border, color, borderRadius, borderType, opacity);
        }
        public Border SetBorder(float border)
        {
            this._Border = border;
            this.BorderLeft = border;
            this.BorderRight = border;
            this.BorderBottom = border;
            this.BorderTop = border;
            return this;
        }
        public Border SetBorderColor(Color color)
        {
            this.Color = color;
            this.BorderColorLeft = color;
            this.BorderColorRight = color;
            this.BorderColorTop = color;
            this.BorderColorBottom = color;
            return this;
        }
        public Border SetBorderOpacity(float opacity)
        {
            this._Opacity = opacity;
            this._OpacityBottom = opacity;
            this._OpacityLeft = opacity;
            this._OpacityRight = opacity;
            this._OpacityTop = opacity;
            return this;
        }
        public Border SetBorderRadius(UnitValue? borderRadius) 
        {
            this._BorderRadius = borderRadius;
            this.BorderRadiusTopLeft = borderRadius;
            this.BorderRadiusBottomRight = borderRadius;
            this.BorderRadiusBottomLeft = borderRadius;
            this.BorderRadiusTopLeft = borderRadius;
            return this;
        } 
        public float GetOpacity() => this._Opacity;
        public float GetBorderWidth() => this._Border;
        public Color GetBorderColor() => this.Color;
        public BorderType GetBorderType() => this._BorderType;
        public UnitValue? GetBorderRadius() => this._BorderRadius;
    }
}
