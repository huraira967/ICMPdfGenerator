using ICMPdfGenerator.Configuration.Constants;
using ICMPdfGenerator.Configuration.Enums;
using ICMPdfGenerator.Models.Data;
using ICMPdfGenerator.Models.Data.CellElements;
using ICMPdfGenerator.Models.Layout.Styles;
//using iText.Layout.Element;

namespace ICMPdfGenerator.Mapper
{
    public class Itext7Mapper : IItext7Mapper
    {
        public iText.Layout.Borders.Border MapToBorder(Border LocalBorder)
        {

            if (LocalBorder == null)
                throw new ArgumentNullException("Local Border must not null to Convert Local border to IText7 border");

            return GetBorderByType(LocalBorder);
        }
        private static iText.Layout.Borders.Border GetBorderByType(Border LocalBorder)
        {
            return LocalBorder.GetBorderType() switch
            {
                BorderType.None => iText.Layout.Borders.Border.NO_BORDER,
                BorderType.Dashed => new iText.Layout.Borders.DashedBorder(GetColor(LocalBorder.GetBorderColor()), LocalBorder.GetBorderWidth(), LocalBorder.GetOpacity()),
                BorderType.Solid => new iText.Layout.Borders.SolidBorder(GetColor(LocalBorder.GetBorderColor()), LocalBorder.GetBorderWidth(), LocalBorder.GetOpacity()),
                BorderType.Dotted => new iText.Layout.Borders.DottedBorder(GetColor(LocalBorder.GetBorderColor()), LocalBorder.GetBorderWidth(), LocalBorder.GetOpacity()),
                _ => new iText.Layout.Borders.SolidBorder(GetColor(LocalBorder.GetBorderColor()), LocalBorder.GetBorderWidth(), LocalBorder.GetOpacity()),
            };
        }

        public iText.Kernel.Colors.Color MapToColor(Color Color)
        {
            return GetColor(Color);
        }

        private static iText.Kernel.Colors.Color GetColor(Color Color)
        {

            return Color switch
            {
                Color.GRAY => iText.Kernel.Colors.DeviceGray.GRAY,
                Color.DARK_GRAY => iText.Kernel.Colors.DeviceGray.MakeDarker(iText.Kernel.Colors.DeviceGray.GRAY),
                Color.LIGHT_GRAY => iText.Kernel.Colors.DeviceGray.MakeLighter(iText.Kernel.Colors.DeviceGray.GRAY),
                Color.BLACK => iText.Kernel.Colors.DeviceRgb.BLACK,
                Color.WHITE => iText.Kernel.Colors.DeviceRgb.WHITE,
                Color.RED => iText.Kernel.Colors.DeviceRgb.RED,
                Color.GREEN => iText.Kernel.Colors.DeviceRgb.GREEN,
                Color.BLUE => iText.Kernel.Colors.DeviceRgb.BLUE,
                _ => iText.Kernel.Colors.DeviceGray.BLACK,
            };
        }

        public iText.Kernel.Geom.PageSize MapToPageSize(PageSize PageSize)
        {
            return GetPageSize(PageSize);
        }
        private iText.Kernel.Geom.PageSize GetPageSize(PageSize PageSize)
        {
            return PageSize switch
            {
                PageSize.A4 => iText.Kernel.Geom.PageSize.A4,
                PageSize.A5 => iText.Kernel.Geom.PageSize.A5,
                PageSize.A6 => iText.Kernel.Geom.PageSize.A6,
                _ => iText.Kernel.Geom.PageSize.A4,
            };
        }

        public Margin MapToMargin(Margin margin)
        {
            return margin;
        }
        public Padding MapToPadding(Padding padding)
        {
            return padding;
        }

        public iText.Layout.Element.Table MapToTable(Table table)
        {
            int columns = table.GetColumns();
            var cells = table.GetCells();
            iText.Layout.Element.Table iText7Table = new iText.Layout.Element.Table(columns);

            foreach (var cell in cells)
            {
                iText7Table.AddCell(GetCell(cell));
            }
            return iText7Table;
        }

        private iText.Layout.Element.Cell GetCell(ICellElement cell)
        {
            iText.Layout.Element.Cell iText7Cell;
            IList<ICellElement> cellContent = new List<ICellElement>();
            if (cell.GetType().Name.Equals(typeof(Cell).Name))
            {
                iText7Cell = new iText.Layout.Element.Cell();
                cellContent = ((Cell)cell).GetCellContent();
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(cell));
            }

            foreach (var content in cellContent)
            {
                if (content.GetType().Name.Equals(typeof(Image).Name))
                {

                }
                else if (content.GetType().Name.Equals(typeof(Paragraph).Name))
                {
                    iText7Cell.Add(ConvertToIText7Paragraph((Paragraph)content));
                }
            }

            return iText7Cell;
        }
        private iText.Layout.Element.Paragraph ConvertToIText7Paragraph(Paragraph paragraph)
        {
            iText.Layout.Element.Paragraph iText7Paragraph = new iText.Layout.Element.Paragraph();
            var paragraphSegments = paragraph.GetParagraphSegments();
            IList<iText.Layout.Element.Text> texts = new List<iText.Layout.Element.Text>();

            foreach (var segment in paragraphSegments)
            {
                var text = new iText.Layout.Element.Text(segment.Value);
                text.SetFontSize((int)segment.FontSize);
                ApplyFontStyle(ref text, segment.FontStyle);
                text.SetFont(CreateFont(segment.FontFamily));
                text.SetHorizontalAlignment(GetHorizontalAlignment(segment.HorizontalAlignment));
                
                iText7Paragraph.Add(text);
            }
            iText7Paragraph.SetTextAlignment(GetTextAlignment(paragraph.GetTextAlignment()));
           
            return iText7Paragraph;
        }
        private static iText.Layout.Element.Text ApplyFontStyle(ref iText.Layout.Element.Text text, FontStyle fontStyle)
        {
            switch (fontStyle)
            {
                case FontStyle.Bold:
                    text.SetBold();
                    break;
                case FontStyle.Italic:
                    text.SetItalic();
                    break;
                case FontStyle.Nomral:
                    break;
                default:
                    break;
            }
            return text;
        }
        private static iText.Layout.Properties.HorizontalAlignment GetHorizontalAlignment(HorizontalAlignment horizontalAlignment)
        {
            return horizontalAlignment switch
            {
                HorizontalAlignment.CENTER => iText.Layout.Properties.HorizontalAlignment.CENTER,
                HorizontalAlignment.LEFT => iText.Layout.Properties.HorizontalAlignment.LEFT,
                HorizontalAlignment.RIGHT => iText.Layout.Properties.HorizontalAlignment.RIGHT,
                _ => iText.Layout.Properties.HorizontalAlignment.LEFT
            };
        }
        private static iText.Layout.Properties.TextAlignment GetTextAlignment(TextAlignment textAlignment)
        {

            return textAlignment switch
            {
                TextAlignment.RIGHT => iText.Layout.Properties.TextAlignment.RIGHT,
                TextAlignment.LEFT => iText.Layout.Properties.TextAlignment.LEFT,
                TextAlignment.CENTER => iText.Layout.Properties.TextAlignment.CENTER,
                TextAlignment.JUSTIFIED => iText.Layout.Properties.TextAlignment.JUSTIFIED,
                TextAlignment.JUSTIFIED_ALL => iText.Layout.Properties.TextAlignment.JUSTIFIED_ALL,
                _ => iText.Layout.Properties.TextAlignment.LEFT,

            };
            
        }

        public iText.Layout.Element.Cell MapToCell(Cell cell)
        {
            throw new NotImplementedException();
        }

        public iText.Layout.Element.Paragraph MapToParagraph(Paragraph paragraph)
        {
            iText.Layout.Element.Paragraph iText7Paragraph = ConvertToIText7Paragraph(paragraph);
            return iText7Paragraph;
        }
        private static iText.Kernel.Font.PdfFont CreateFont(string fontFamily)
        {
            iText.Kernel.Font.PdfFont pdfFont = fontFamily switch
            {
                FontFamily.COURIER => (iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.COURIER)),
                FontFamily.COURIER_BOLD => (iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.COURIER_BOLD)),
                FontFamily.COURIER_BOLDOBLIQUE => (iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.COURIER_BOLDOBLIQUE)),
                FontFamily.COURIER_OBLIQUE => (iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.COURIER_OBLIQUE)),
                FontFamily.HELVETICA => (iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA)),
                FontFamily.SYMBOL => (iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.SYMBOL)),
                FontFamily.TIMES_ROMAN => (iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.TIMES_ROMAN)),
                FontFamily.ZAPFDINGBATS => (iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.ZAPFDINGBATS)),
                FontFamily.HELVETICA_BOLD => (iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD)),
                FontFamily.HELVETICA_BOLDOBLIQUE => (iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLDOBLIQUE)),
                FontFamily.TIMES_BOLD => (iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.TIMES_BOLD)),
                FontFamily.TIMES_BOLDITALIC => (iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.TIMES_BOLDITALIC)),
                FontFamily.TIMES_ITALIC => (iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.TIMES_ITALIC)),
                _ => (iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA)),
            };
            return pdfFont;
        }
        private static iText.Layout.Properties.BaseDirection GetBaseDirection(BaseDirection baseDirection)
        {
            
          return baseDirection switch
            {
                BaseDirection.NO_BIDI => iText.Layout.Properties.BaseDirection.NO_BIDI,
                BaseDirection.DEFAULT_BIDI => iText.Layout.Properties.BaseDirection.DEFAULT_BIDI,
                BaseDirection.RIGHT_TO_LEFT => iText.Layout.Properties.BaseDirection.RIGHT_TO_LEFT,
                BaseDirection.LEFT_TO_RIGHT => iText.Layout.Properties.BaseDirection.LEFT_TO_RIGHT,
                _ => iText.Layout.Properties.BaseDirection.LEFT_TO_RIGHT,
            };
        }
        private static iText.Layout.Properties.UnitValue MapToUnitValue(UnitValue unitValue)
        {
            //in itext7 1 is for
            //1 point
            //2  percent
            int unitType = unitValue.IsPercentage ? 1 : unitValue.IsAbsolute ? 2 : 1;

            iText.Layout.Properties.UnitValue iText7UnitValue = new(unitType, unitValue.Value);
            return iText7UnitValue;
        }
        private static iText.Layout.Hyphenation.HyphenationConfig GetHyphenation(HyphenationConfiguration hyphenationConfiguration)
        {
            return new iText.Layout.Hyphenation.HyphenationConfig(hyphenationConfiguration.Left, hyphenationConfiguration.Right);
        }
        private static iText.Layout.Style MapToStyle(Style style)
        {
            iText.Layout.Style iText7Style = new();

            switch (style.FontStyle)
            {
                case FontStyle.Bold:
                    iText7Style.SetBold();
                    break;
                case FontStyle.Italic:
                    iText7Style.SetItalic();
                    break;
                case FontStyle.Nomral:
                    break;
                default:
                    break;
            }
            iText7Style.SetBackgroundColor(GetColor(style.BackgroundColor));

            iText7Style.SetBaseDirection(GetBaseDirection(style.BaseDirection));
            iText7Style.SetBorder(GetBorderByType(style.Border));
            iText7Style.SetCharacterSpacing(style.CharacterSpacing);
            iText7Style.SetFixedPosition(style.FixedPosition.Left,style.FixedPosition.Bottom, MapToUnitValue(style.FixedPosition.Width));
            iText7Style.SetFont(CreateFont(style.FontFamily));
            iText7Style.SetFontColor(GetColor(style.FontColor));
            iText7Style.SetFontSize((int)style.FontSize);
            iText7Style.SetHeight(MapToUnitValue(style.Height));
            iText7Style.SetHorizontalAlignment(GetHorizontalAlignment(style.HorizontalAlignment));
            iText7Style.SetHyphenation(GetHyphenation(style.Hyphenation));
            iText7Style.SetKeepTogether(style.KeepTogather);

            return iText7Style;
        }

       

    }
    public class temp
    {
        public FontStyle FontStyle { get; set; } //done
        public Color BackgroundColor { get; set; } //done
        public BaseDirection BaseDirection { get; set; } //done

        public Border Border { get; set; } //done
        public float CharacterSpacing { get; set; } //done
        public FixefPosition FixedPosition { get; set; } //done
        public string FontFamily { get; set; } //we will use pre-built font which //done
        public Color FontColor { get; set; } //done
        public FontSize FontSize { get; set; } // done
        public UnitValue Height { get; set; } //done
        public HorizontalAlignment HorizontalAlignment { get; set; } //done
        public HyphenationConfiguration Hyphenation { get; set; } //done
        public bool KeepTogather { get; set; } //done
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
