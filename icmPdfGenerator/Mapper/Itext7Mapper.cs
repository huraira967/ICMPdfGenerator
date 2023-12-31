﻿using ICMPdfGenerator.ICMProperties.Constants;
using ICMPdfGenerator.ICMProperties.Enums;
using ICMPdfGenerator.Models.ICMPdfElements;
using ICMPdfGenerator.Models.ICMPdfElements.CellElements;
using ICMPdfGenerator.Models.ICMPdfLayout.Elements;


namespace ICMPdfGenerator.Mapper
{
#pragma warning disable IDE1006 // Naming Elements
    public class iText7Mapper : IPdfMapper
#pragma warning restore IDE1006 // Naming Elements
    {
        public object MapToBorder<TResult>(Border LocalBorder)
        {
            if (!typeof(TResult).Equals(typeof(iText.Layout.Borders.Border)))
                throw new NotSupportedException($"{typeof(TResult)} is not Supported. TResult must be of type {typeof(iText.Layout.Borders.Border)}.");

            if (LocalBorder == null)
                throw new ArgumentNullException("Local Border must not null to Convert Local border to IText7 border");

            return GetBorder(LocalBorder);
        }
        public object MapToImage<TResult>(Image image)
        {
            if (!typeof(TResult).Equals(typeof(iText.Layout.Element.Image)))
                throw new NotSupportedException($"{typeof(TResult)} is not Supported. TResult must be of type {typeof(iText.Layout.Element.Image)}.");
            return GetImage(image);
        }
        public object MapToLineSeparator<TResult>(LineSeparator lineSeparator)
        {
            if (!typeof(TResult).Equals(typeof(iText.Layout.Element.LineSeparator)))
                throw new NotSupportedException($"{typeof(TResult)} is not Supported. TResult must be of type {typeof(iText.Layout.Element.LineSeparator)}.");

            iText.Layout.Element.LineSeparator itext7SineSeparator = new iText.Layout.Element.LineSeparator(GetLine(lineSeparator.Line));
            itext7SineSeparator.AddStyle(MapToStyle(lineSeparator.Styles));
            return itext7SineSeparator;
        }
        public object MapToColor<TResult>(Color Color)
        {
            if (!typeof(TResult).Equals(typeof(iText.Kernel.Colors.Color)))
                throw new NotSupportedException($"{typeof(TResult)} is not Supported. TResult must be of type {typeof(iText.Kernel.Colors.Color)}.");

            return GetColor(Color);
        }
        public object MapToPageSize<TResult>(PageSize PageSize)
        {
            if(!typeof(TResult).Equals(typeof(iText.Kernel.Geom.PageSize)))
                throw new NotSupportedException($"{typeof(TResult)} is not Supported. TResult must be of type {typeof(iText.Kernel.Geom.PageSize)}.");
            

            return GetPageSize(PageSize);
        }
        public object MapToParagraph<TResult>(Paragraph paragraph)
        {
            if (!typeof(TResult).Equals(typeof(iText.Layout.Element.Paragraph)))
                throw new NotSupportedException($"{typeof(TResult)} is not Supported. TResult must be of type {typeof(iText.Layout.Element.Paragraph)}.");

            return ConvertToIText7Paragraph(paragraph);
        }
        public object MapToTable<TResult>(Table table)
        {
            if (!typeof(TResult).Equals(typeof(iText.Layout.Element.Table)))
                throw new NotSupportedException($"{typeof(TResult)} is not Supported. TResult must be of type {typeof(iText.Layout.Element.Table)}.");

            iText.Layout.Element.Table iText7Table = new(table.GetColumns());
            iText7Table.AddStyle(MapToStyle(table.Styles));

            var cells = table.GetCells();

            foreach (var cell in cells)
            {
                if (cell.GetType().Name.Equals(typeof(Cell).Name))
                {
                    iText7Table.AddCell((iText.Layout.Element.Cell)MapToCell<iText.Layout.Element.Cell>((Cell)cell));
                }
            }
            return iText7Table;
        }

        public object MapToCell<TResult>(Cell cell)
        {
            if (!typeof(TResult).Equals(typeof(iText.Layout.Element.Cell)))
                throw new NotSupportedException($"{typeof(TResult)} is not Supported. TResult must be of type {typeof(iText.Layout.Element.Cell)}.");

            iText.Layout.Element.Cell iText7Cell = new(cell.RowSpan, cell.ColSpan);
            var cellStyles = MapToStyle(cell.Styles);
            iText7Cell.AddStyle(cellStyles);
            iText7Cell.SetBorderRadius(new iText.Layout.Properties.BorderRadius(100));
            var cellContent = cell.GetCellContent();

            foreach (var content in cellContent)
            {
                if (content.GetType().Name.Equals(typeof(Cell).Name))
                {
                    iText7Cell.Add((iText.Layout.Element.Cell)MapToCell<iText.Layout.Element.Cell>((Cell)content));
                }
                else if (content.GetType().Name.Equals(typeof(Table).Name))
                {
                    iText7Cell.Add((iText.Layout.Element.Table)MapToTable<iText.Layout.Element.Table>((Table)content));
                }
                else if (content.GetType().Name.Equals(typeof(Image).Name))
                {
                    iText7Cell.Add(GetImage((Image)content));
                }
                else if (content.GetType().Name.Equals(typeof(Paragraph).Name))
                {
                    iText7Cell.Add(ConvertToIText7Paragraph((Paragraph)content));
                }
            }
            return iText7Cell;
        }
        public object MapToBlockElement<TResult>(ICellElement cellElement)
        {
            if (!typeof(TResult).Equals(typeof(iText.Layout.Element.IBlockElement)))
                throw new NotSupportedException($"{typeof(TResult)} is not Supported. TResult must be of type {typeof(iText.Layout.Element.IBlockElement)}.");

            if (cellElement.GetType().Name.Equals(typeof(Cell).Name))
            {
                return (iText.Layout.Element.Cell)MapToCell<iText.Layout.Element.Cell>((Cell)cellElement);
            }
            else if (cellElement.GetType().Name.Equals(typeof(Table).Name))
            {
                return (iText.Layout.Element.Table)MapToTable<iText.Layout.Element.Table>((Table)cellElement);
            }
            else if (cellElement.GetType().Name.Equals(typeof(Paragraph).Name))
            {
                return ConvertToIText7Paragraph((Paragraph)cellElement);
            }
            throw new NotImplementedException($"only {nameof(Cell)}, {nameof(Table)}, {nameof(Paragraph)} are allowed to add in footer");
        }
        public object MapToVerticalSpace<TResult>(float points)
        {
            if (!typeof(TResult).Equals(typeof(iText.Layout.Element.Table)))
                throw new NotSupportedException($"{typeof(TResult)} is not Supported. TResult must be of type {typeof(iText.Layout.Element.Table)}.");

            iText.Layout.Element.Table table = new(1);
            table.SetMarginTop(points);
            return table;
        }
        private static iText.Layout.Element.Image GetImage(Image image)
        {
            iText.IO.Image.ImageData imageData = iText.IO.Image.ImageDataFactory.Create(image.GetImageBytes());
            iText.Layout.Element.Image iText7Image = new iText.Layout.Element.Image(imageData);
            iText7Image.AddStyle(MapToStyle(image.Styles));

            return iText7Image;
        }
        private static iText.Layout.Properties.BorderRadius GetBorderRadius(Border LocalBorder)
        {
            iText.Layout.Properties.BorderRadius borderRadius = new iText.Layout.Properties.BorderRadius(MapToUnitValue(LocalBorder.GetBorderRadius()));
            return borderRadius;
        }
        private static iText.Layout.Properties.BorderRadius GetBorderRadiusBottomLeft(Border LocalBorder)
        {
            iText.Layout.Properties.BorderRadius borderRadius = new iText.Layout.Properties.BorderRadius(MapToUnitValue(LocalBorder.GetBorderRadiusBottomLeft()));
            return borderRadius;
        }
        private static iText.Layout.Properties.BorderRadius GetBorderRadiusBottomRight(Border LocalBorder)
        {
            iText.Layout.Properties.BorderRadius borderRadius = new iText.Layout.Properties.BorderRadius(MapToUnitValue(LocalBorder.GetBorderRadiusBottomRight()));
            return borderRadius;
        }
        private static iText.Layout.Properties.BorderRadius GetBorderRadiusTopLeft(Border LocalBorder)
        {
            iText.Layout.Properties.BorderRadius borderRadius = new iText.Layout.Properties.BorderRadius(MapToUnitValue(LocalBorder.GetBorderRadiusTopLeft()));
            return borderRadius;
        }
        private static iText.Layout.Properties.BorderRadius GetBorderRadiusTopRight(Border LocalBorder)
        {
            iText.Layout.Properties.BorderRadius borderRadius = new iText.Layout.Properties.BorderRadius(MapToUnitValue(LocalBorder.GetBorderRadiusTopRight()));
            return borderRadius;
        }
        private static iText.Layout.Borders.Border GetBorder(Border LocalBorder)
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
        private static iText.Layout.Borders.Border GetBorderRight(Border LocalBorder)
        {
            return LocalBorder.GetBorderTypeRight() switch
            {
                BorderType.None => iText.Layout.Borders.Border.NO_BORDER,
                BorderType.Dashed => new iText.Layout.Borders.DashedBorder(GetColor(LocalBorder.GetBorderColorRight()), LocalBorder.GetBorderRight(), LocalBorder.GetBorderOpacityRight()),
                BorderType.Solid => new iText.Layout.Borders.SolidBorder(GetColor(LocalBorder.GetBorderColorRight()), LocalBorder.GetBorderRight(), LocalBorder.GetBorderOpacityRight()),
                BorderType.Dotted => new iText.Layout.Borders.DottedBorder(GetColor(LocalBorder.GetBorderColorRight()), LocalBorder.GetBorderRight(), LocalBorder.GetBorderOpacityRight()),
                _ => new iText.Layout.Borders.SolidBorder(GetColor(LocalBorder.GetBorderColorRight()), LocalBorder.GetBorderRight(), LocalBorder.GetBorderOpacityRight()),
            };
        }
        private static iText.Layout.Borders.Border GetBorderLeft(Border LocalBorder)
        {
            return LocalBorder.GetBorderTypeLeft() switch
            {
                BorderType.None => iText.Layout.Borders.Border.NO_BORDER,
                BorderType.Dashed => new iText.Layout.Borders.DashedBorder(GetColor(LocalBorder.GetBorderColorLeft()), LocalBorder.GetBorderLeft(), LocalBorder.GetBorderOpacityLeft()),
                BorderType.Solid => new iText.Layout.Borders.SolidBorder(GetColor(LocalBorder.GetBorderColorLeft()), LocalBorder.GetBorderLeft(), LocalBorder.GetBorderOpacityLeft()),
                BorderType.Dotted => new iText.Layout.Borders.DottedBorder(GetColor(LocalBorder.GetBorderColorLeft()), LocalBorder.GetBorderLeft(), LocalBorder.GetBorderOpacityLeft()),
                _ => new iText.Layout.Borders.SolidBorder(GetColor(LocalBorder.GetBorderColorLeft()), LocalBorder.GetBorderLeft(), LocalBorder.GetBorderOpacityLeft()),
            };
        }
        private static iText.Layout.Borders.Border GetBorderBottom(Border LocalBorder)
        {
            return LocalBorder.GetBorderTypeBottom() switch
            {
                BorderType.None => iText.Layout.Borders.Border.NO_BORDER,
                BorderType.Dashed => new iText.Layout.Borders.DashedBorder(GetColor(LocalBorder.GetBorderColorBottom()), LocalBorder.GetBorderBottom(), LocalBorder.GetBorderOpacityBottom()),
                BorderType.Solid => new iText.Layout.Borders.SolidBorder(GetColor(LocalBorder.GetBorderColorBottom()), LocalBorder.GetBorderBottom(), LocalBorder.GetBorderOpacityBottom()),
                BorderType.Dotted => new iText.Layout.Borders.DottedBorder(GetColor(LocalBorder.GetBorderColorBottom()), LocalBorder.GetBorderBottom(), LocalBorder.GetBorderOpacityBottom()),
                _ => new iText.Layout.Borders.SolidBorder(GetColor(LocalBorder.GetBorderColorBottom()), LocalBorder.GetBorderBottom(), LocalBorder.GetBorderOpacityBottom()),
            };
        }
        private static iText.Layout.Borders.Border GetBorderTop(Border LocalBorder)
        {
            return LocalBorder.GetBorderTypeTop() switch
            {
                BorderType.None => iText.Layout.Borders.Border.NO_BORDER,
                BorderType.Dashed => new iText.Layout.Borders.DashedBorder(GetColor(LocalBorder.GetBorderColorTop()), LocalBorder.GetBorderTop(), LocalBorder.GetBorderOpacityTop()),
                BorderType.Solid => new iText.Layout.Borders.SolidBorder(GetColor(LocalBorder.GetBorderColorTop()), LocalBorder.GetBorderTop(), LocalBorder.GetBorderOpacityTop()),
                BorderType.Dotted => new iText.Layout.Borders.DottedBorder(GetColor(LocalBorder.GetBorderColorTop()), LocalBorder.GetBorderTop(), LocalBorder.GetBorderOpacityTop()),
                _ => new iText.Layout.Borders.SolidBorder(GetColor(LocalBorder.GetBorderColorTop()), LocalBorder.GetBorderTop(), LocalBorder.GetBorderOpacityTop()),
            };
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



        private iText.Layout.Element.Paragraph ConvertToIText7Paragraph(Paragraph paragraph)
        {
            iText.Layout.Element.Paragraph iText7Paragraph = new iText.Layout.Element.Paragraph();
            iText7Paragraph.AddStyle(MapToStyle(paragraph.Styles));

            var paragraphSegments = paragraph.GetParagraphSegments();

            foreach (var segment in paragraphSegments)
            {
                var text = new iText.Layout.Element.Text(segment.Value);
                text.AddStyle(MapToStyle(segment.Styles));

                iText7Paragraph.Add(text);
            }
            return iText7Paragraph;
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
        private static iText.Layout.Properties.VerticalAlignment GetVerticalAlignment(VerticalAlignment verticalAlignment)
        {
            return verticalAlignment switch
            {
                VerticalAlignment.MIDDLE => iText.Layout.Properties.VerticalAlignment.MIDDLE,
                VerticalAlignment.BOTTOM => iText.Layout.Properties.VerticalAlignment.BOTTOM,
                VerticalAlignment.TOP => iText.Layout.Properties.VerticalAlignment.TOP,
                _ => iText.Layout.Properties.VerticalAlignment.TOP
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
            //int unitType = unitValue.IsPercentage ? 1 : (unitValue.IsAbsolute ? 2 : 1);

            return unitValue.IsPercentage ? iText.Layout.Properties.UnitValue.CreatePercentValue(unitValue.Value)
                                         : iText.Layout.Properties.UnitValue.CreatePointValue(unitValue.Value);

        }
        private static iText.Layout.Hyphenation.HyphenationConfig GetHyphenation(HyphenationConfiguration hyphenationConfiguration)
        {
            return new iText.Layout.Hyphenation.HyphenationConfig(hyphenationConfiguration.Left, hyphenationConfiguration.Right);
        }
        private static iText.Kernel.Pdf.Canvas.Draw.ILineDrawer GetLine(Line line)
        {
            switch (line.LineType)
            {
                case LineType.Solid:
                    var soildLine = new iText.Kernel.Pdf.Canvas.Draw.SolidLine();
                    soildLine.SetColor(GetColor(line.LineColor));
                    soildLine.SetLineWidth(line.LineWidth);
                    return soildLine;
                case LineType.Dotted:
                    var dottedLine = new iText.Kernel.Pdf.Canvas.Draw.DottedLine();
                    dottedLine.SetColor(GetColor(line.LineColor));
                    dottedLine.SetGap(line.Gap);
                    dottedLine.SetLineWidth(line.LineWidth);
                    return dottedLine;
                case LineType.Dashed:
                    var dashedLine = new iText.Kernel.Pdf.Canvas.Draw.DashedLine();
                    dashedLine.SetColor(GetColor(line.LineColor));
                    dashedLine.SetLineWidth(line.LineWidth);
                    return dashedLine;
                default:
                    soildLine = new iText.Kernel.Pdf.Canvas.Draw.SolidLine();
                    soildLine.SetColor(GetColor(line.LineColor));
                    soildLine.SetLineWidth(line.LineWidth);
                    return soildLine;
            }

        }
        private static iText.Layout.Style MapToStyle(Style style)
        {
            if (style == null)
                throw new ArgumentNullException(nameof(style));

            iText.Layout.Style iText7Style = new();

            switch (style.FontStyle)
            {
                case FontStyle.Bold:
                    iText7Style.SetBold();
                    break;
                case FontStyle.Italic:
                    iText7Style.SetItalic();
                    break;
                case FontStyle.BoldItalic:
                    iText7Style.SetBold();
                    iText7Style.SetItalic();
                    break;
                case FontStyle.Nomral:
                    break;
                default:
                    break;
            }
            iText7Style.SetBackgroundColor(GetColor(style.BackgroundColor));

            iText7Style.SetBaseDirection(GetBaseDirection(style.BaseDirection));

            iText7Style.SetFont(CreateFont(style.FontFamily));

            iText7Style.SetFontColor(GetColor(style.FontColor));
            iText7Style.SetFontSize((int)style.FontSize);
            iText7Style.SetHorizontalAlignment(GetHorizontalAlignment(style.HorizontalAlignment));
            iText7Style.SetVerticalAlignment(GetVerticalAlignment(style.VerticalAlignment));

            iText7Style.SetTextAlignment(GetTextAlignment(style.TextAlignment));

            if (style.Border != null)
            {

                if (style.Border.GetBorderRadius() != null)
                {
                    iText7Style.SetBorderRadius(GetBorderRadius(style.Border));
                    iText7Style.SetBorderTopRightRadius(GetBorderRadiusTopRight(style.Border));
                    iText7Style.SetBorderTopLeftRadius(GetBorderRadiusTopLeft(style.Border));
                    iText7Style.SetBorderBottomRightRadius(GetBorderRadiusBottomRight(style.Border));
                    iText7Style.SetBorderBottomLeftRadius(GetBorderRadiusBottomLeft(style.Border));
                }


                iText7Style.SetBorder(GetBorder(style.Border));
                iText7Style.SetBorderTop(GetBorderTop(style.Border));
                iText7Style.SetBorderRight(GetBorderRight(style.Border));
                iText7Style.SetBorderLeft(GetBorderLeft(style.Border));
                iText7Style.SetBorderBottom(GetBorderBottom(style.Border));






            }
            if (style.CharacterSpacing > -1)
            {
                iText7Style.SetCharacterSpacing(style.CharacterSpacing);
            }
            if (style.FixedPosition != null)
            {
                iText7Style.SetFixedPosition(style.FixedPosition.Left, style.FixedPosition.Bottom, MapToUnitValue(style.FixedPosition.Width));
            }
            if (style.Height != null)
            {
                iText7Style.SetHeight(MapToUnitValue(style.Height));
            }
            if (style.Hyphenation != null)
            {
                iText7Style.SetHyphenation(GetHyphenation(style.Hyphenation));
            }
            if (style.KeepTogather)
            {
                iText7Style.SetKeepTogether(style.KeepTogather);
            }
            if (style.Margin != null)
            {
                iText7Style.SetMarginBottom(style.Margin.MarginBottom);
                iText7Style.SetMarginTop(style.Margin.MarginTop);
                iText7Style.SetMarginLeft(style.Margin.MarginLeft);
                iText7Style.SetMarginRight(style.Margin.MarginRight);
            }
            if (style.MaxHeight != null)
            {
                iText7Style.SetMaxHeight(MapToUnitValue(style.MaxHeight));
            }
            if (style.MinHeight != null)
            {
                iText7Style.SetMinHeight(MapToUnitValue(style.MinHeight));
            }
            if (style.MaxWidth != null)
            {
                iText7Style.SetMaxWidth(MapToUnitValue(style.MaxWidth));
            }
            if (style.MinWidth != null)
            {
                iText7Style.SetMinWidth(MapToUnitValue(style.MinWidth));
            }
            if (style.Opacity > -1)
            {
                iText7Style.SetOpacity(style.Opacity);
            }
            if (style.Padding != null)
            {
                iText7Style.SetPaddingBottom(style.Padding.PaddingBottom);
                iText7Style.SetPaddingLeft(style.Padding.PaddingLeft);
                iText7Style.SetPaddingRight(style.Padding.PaddingRight);
                iText7Style.SetPaddingTop(style.Padding.PaddingTop);
            }
            if (style.Rotation != -1)
            {
                iText7Style.SetRotationAngle(style.Rotation);
            }
            if (style.SpacingRatio != -1)
            {
                iText7Style.SetSpacingRatio(style.SpacingRatio);
            }

            if (style.Underline)
            {
                iText7Style.SetUnderline();
            }

            if (style.Width != null)
            {
                iText7Style.SetWidth(MapToUnitValue(style.Width));
            }
            if (style.WordSpacing != -1)
            {
                iText7Style.SetWordSpacing(style.WordSpacing);
            }


            return iText7Style;
        }


    }
}
