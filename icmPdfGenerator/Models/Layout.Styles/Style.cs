using ICMPdfGenerator.Configuration.Constants;
using ICMPdfGenerator.Configuration.Enums;

namespace ICMPdfGenerator.Models.Layout.Styles
{
    public class Style
    {
        public Color BackgroundColor { get; set; } = Color.WHITE;
        public BaseDirection BaseDirection { get; set; } = BaseDirection.LEFT_TO_RIGHT;
        public FontStyle FontStyle { get; set; } = FontStyle.Nomral;
        public Border? Border { get; set; } = null;
        public float CharacterSpacing { get; set; } = -1;
        public FixefPosition? FixedPosition { get; set; } = null;
        public string FontFamily { get; set; } = ICMPdfGenerator.Configuration.Constants.FontFamily.HELVETICA;//we will use pre-built font which
        public Color FontColor { get; set; } = Color.BLACK;
        public FontSize FontSize { get; set; } = FontSize.Px10;
        public UnitValue? Height { get; set; } = null;
        public HorizontalAlignment HorizontalAlignment { get; set; } = HorizontalAlignment.LEFT;
        public HyphenationConfiguration? Hyphenation { get; set; } = null;
        public bool KeepTogather { get; set; } = false;
        public Margin? Margin { get; set; } = null; 
        public UnitValue? MaxHeight { get; set; } = null;
        public UnitValue? MinHeight { get; set; } = null;
        public UnitValue? MaxWidth { get; set; } = null;
        public UnitValue? MinWidth { get; set; } = null;
        public float Opacity { get; set; } = -1;
        public Padding? Padding { get; set; } = null;
        public float Rotation { get; set; } = -1;
        public float SpacingRatio { get; set; } = -1;
        public TextAlignment TextAlignment { get; set; } = TextAlignment.LEFT;
        public bool Underline { get; set; } = false;
        public VerticalAlignment VerticalAlignment { get; set; } = VerticalAlignment.TOP;
        public UnitValue? Width { get; set; } = null;
        public float WordSpacing { get; set; } = -1;
    }
  
    
}
