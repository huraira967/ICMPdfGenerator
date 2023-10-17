using ICMPdfGenerator.Configuration.Enums;

namespace ICMPdfGenerator.Models.Layout.Styles
{
    public class Style
    {
        public Color BackgroundColor { get; set; }
        public BaseDirection BaseDirection { get; set; }
        public FontStyle FontStyle { get; set; }
        public Border Border { get; set; }
        public float CharacterSpacing { get; set; }
        public FixefPosition FixedPosition { get; set; }
        public string FontFamily { get; set; } //we will use pre-built font which
        public Color FontColor { get; set; }
        public FontSize FontSize { get; set; }
        public UnitValue Height { get; set; }
        public HorizontalAlignment HorizontalAlignment { get; set; }
        public HyphenationConfiguration Hyphenation { get; set; }
        public bool KeepTogather { get; set; }
        public Margin Margin { get; set; }
        public UnitValue MaxHeight { get; set; }
        public UnitValue MinHeight { get; set; }
        public UnitValue MaxWidth { get; set; }
        public UnitValue MinWidth { get; set; }
        public float Opacity { get; set; }
        public Padding Padding { get; set; }
        public float Rotation { get; set; }
        public float SpacingRatio { get; set; }
        public TextAlignment TextAlignment { get; set; }
        public bool Underline { get; set; }
        public VerticalAlignment VerticalAlignment { get; set; }
        public UnitValue Width { get; set; }
        public float WordSpacing { get; set; }
    }
  
    
}
