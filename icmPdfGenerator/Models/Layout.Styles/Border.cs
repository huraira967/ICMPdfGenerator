using ICMPdfGenerator.Configuration.Enums;
using iText.Layout.Borders;

namespace ICMPdfGenerator.Models.Layout.Styles
{
    public partial class Border
    {
        private BorderType _BorderType { get; set; } = BorderType.Solid;
        private float _Opacity { get; set; } = 1;
        private float _Border { get; set; }
        private Color Color { get; set; }
        private float _BorderRadius { get; set; }
        
        public Border(float border = 1, BorderType borderType = BorderType.Solid, Color color = Color.BLACK)
        {
            this._BorderType = borderType;
            this.Color = color;
        }
        public Border SetBorder(float border)
        {
            this._Border = border;
            return this;
        }
        public Border SetBorderColor(Color color)
        {
            this.Color = color;
            return this;
        }
        public Border SetBorderOpacity(float opacity)
        {
            this._Opacity = opacity;
            return this;
        }
        public Border SetBorderRadius(float borderRadius) 
        {
            this._BorderRadius = borderRadius;
            return this;
        } 
        public float GetOpacity() => this._Opacity;
        public float GetBorderWidth() => this._Border;
        public Color GetBorderColor() => this.Color;
        public BorderType GetBorderType() => this._BorderType;
        public float GetBorderRadius() => this._BorderRadius;
    }
}
