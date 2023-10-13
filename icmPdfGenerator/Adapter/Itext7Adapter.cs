using ICMPdfGenerator.Configuration.Constants;
using ICMPdfGenerator.Configuration.Enums;
using ICMPdfGenerator.Models.Data;
using ICMPdfGenerator.Models.Data.CellElements;
using ICMPdfGenerator.Models.Layout.Styles;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;

namespace ICMPdfGenerator.Adapter
{
    public class Itext7Adapter : IItext7Adapter
    {
        public iText.Layout.Borders.Border ConvertToBorder(Models.Layout.Styles.Border LocalBorder)
        {

            if (LocalBorder == null)
                throw new ArgumentNullException("Local Border must not null to Convert Local border to IText7 border");

            return GetBorderByType(LocalBorder);
        }
        private iText.Layout.Borders.Border GetBorderByType(Models.Layout.Styles.Border LocalBorder)
        {
            switch (LocalBorder.GetBorderType())
            {
                case BorderType.None:
                    return iText.Layout.Borders.Border.NO_BORDER;
                case BorderType.Dashed:
                    return new iText.Layout.Borders.DashedBorder(GetColor(LocalBorder.GetBorderColor()), LocalBorder.GetBorderWidth(), LocalBorder.GetOpacity());
                case BorderType.Solid:
                    return new iText.Layout.Borders.SolidBorder(GetColor(LocalBorder.GetBorderColor()), LocalBorder.GetBorderWidth(), LocalBorder.GetOpacity());
                case BorderType.Dotted:
                    return new iText.Layout.Borders.DottedBorder(GetColor(LocalBorder.GetBorderColor()), LocalBorder.GetBorderWidth(), LocalBorder.GetOpacity());
                default:
                    return new iText.Layout.Borders.SolidBorder(GetColor(LocalBorder.GetBorderColor()), LocalBorder.GetBorderWidth(), LocalBorder.GetOpacity());
            }
        }

        public iText.Kernel.Colors.Color ConvertToColor(Configuration.Enums.Color Color)
        {
            return GetColor(Color);
        }

        private iText.Kernel.Colors.Color GetColor(Configuration.Enums.Color Color)
        {

            switch (Color)
            {
                case Configuration.Enums.Color.GRAY:
                    return DeviceGray.GRAY;
                case Configuration.Enums.Color.DARK_GRAY:
                    return DeviceGray.MakeDarker(DeviceGray.GRAY);
                case Configuration.Enums.Color.LIGHT_GRAY:
                    return DeviceGray.MakeLighter(DeviceGray.GRAY);
                case Configuration.Enums.Color.BLACK:
                    return DeviceRgb.BLACK;
                case Configuration.Enums.Color.WHITE:
                    return DeviceRgb.WHITE;
                case Configuration.Enums.Color.RED:
                    return DeviceRgb.RED;
                case Configuration.Enums.Color.GREEN:
                    return DeviceRgb.GREEN;
                case Configuration.Enums.Color.BLUE:
                    return DeviceRgb.BLUE;
                default:
                    return DeviceGray.BLACK;
            }
        }

        public iText.Kernel.Geom.PageSize ConvertToPageSize(Configuration.Enums.PageSize PageSize)
        {
            return GetPageSize(PageSize);
        }
        private iText.Kernel.Geom.PageSize GetPageSize(Configuration.Enums.PageSize PageSize)
        {
            switch (PageSize)
            {
                case Configuration.Enums.PageSize.A4:
                    return iText.Kernel.Geom.PageSize.A4;
                case Configuration.Enums.PageSize.A5:
                    return iText.Kernel.Geom.PageSize.A5;
                case Configuration.Enums.PageSize.A6:
                    return iText.Kernel.Geom.PageSize.A6;
                default:
                    return iText.Kernel.Geom.PageSize.A4;
            }
        }

        public Margin ConvertToMargin(Margin margin)
        {
            return margin;
        }
        public Padding ConvertToPadding(Padding padding)
        {
            return padding;
        }

        public iText.Layout.Element.Table ConvertToTable(Models.Data.Table table)
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

        private iText.Layout.Element.Cell GetCell(Models.Data.CellElements.ICellElement cell)
        {
            iText.Layout.Element.Cell iText7Cell;
            IList<ICellElement> cellContent = new List<ICellElement>();
            if (cell.GetType().Name.Equals(typeof(Models.Data.Cell).Name))
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
                if (content.GetType().Name.Equals(typeof(Models.Data.CellElements.Image).Name))
                {

                }
                else if (content.GetType().Name.Equals(typeof(Models.Data.CellElements.Paragraph).Name))
                {
                    iText7Cell.Add(ConvertToIText7Paragraph((Paragraph)content));
                }
            }

            return iText7Cell;
        }
        private iText.Layout.Element.Paragraph ConvertToIText7Paragraph(Models.Data.CellElements.Paragraph paragraph)
        {
            iText.Layout.Element.Paragraph iText7Paragraph = new iText.Layout.Element.Paragraph();
            var paragraphSegments = paragraph.GetParagraphSegments();
            IList<iText.Layout.Element.Text> texts = new List<iText.Layout.Element.Text>();

            foreach (var segment in paragraphSegments)
            {
                var text = new iText.Layout.Element.Text(segment.Value);
                text.SetFontSize((int)segment.FontSize);
                switch (segment.FontStyle)
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

                switch (segment.FontFamily)
                {
                    case FontFamily.COURIER:
                        text.SetFont(PdfFontFactory.CreateFont(StandardFonts.COURIER));
                        break;
                    case FontFamily.COURIER_BOLD:
                        text.SetFont(PdfFontFactory.CreateFont(StandardFonts.COURIER_BOLD));
                        break;
                    case FontFamily.COURIER_BOLDOBLIQUE:
                        text.SetFont(PdfFontFactory.CreateFont(StandardFonts.COURIER_BOLDOBLIQUE));
                        break;
                    case FontFamily.COURIER_OBLIQUE:
                        text.SetFont(PdfFontFactory.CreateFont(StandardFonts.COURIER_OBLIQUE));
                        break;
                    case FontFamily.HELVETICA:
                        text.SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA));
                        break;
                    case FontFamily.SYMBOL:
                        text.SetFont(PdfFontFactory.CreateFont(StandardFonts.SYMBOL));
                        break;
                    case FontFamily.TIMES_ROMAN:
                        text.SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN));
                        break;
                    case FontFamily.ZAPFDINGBATS:
                        text.SetFont(PdfFontFactory.CreateFont(StandardFonts.ZAPFDINGBATS));
                        break;
                    case FontFamily.HELVETICA_BOLD:
                        text.SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD));
                        break;
                    case FontFamily.HELVETICA_BOLDOBLIQUE:
                        text.SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLDOBLIQUE));
                        break;
                    case FontFamily.TIMES_BOLD:
                        text.SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD));
                        break;
                    case FontFamily.TIMES_BOLDITALIC:
                        text.SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLDITALIC));
                        break;
                    case FontFamily.TIMES_ITALIC:
                        text.SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_ITALIC));
                        break;
                    default:
                        text.SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA));
                        break;

                }
                switch (segment.HorizontalAlignment)
                {
                    case HorizontalAlignment.CENTER:
                        text.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                        break;
                    case HorizontalAlignment.RIGHT:
                        text.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.RIGHT);
                        break;
                    case HorizontalAlignment.LEFT:
                        text.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.LEFT);
                        break;
                }

                iText7Paragraph.Add(text);
            }

            switch (paragraph.GetTextAlignment())
            {
                case TextAlignment.RIGHT:
                    iText7Paragraph.SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT);
                    break;
                case TextAlignment.LEFT:
                    iText7Paragraph.SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);
                    break;
                case TextAlignment.CENTER:
                    iText7Paragraph.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    break;
                case TextAlignment.JUSTIFIED:
                    iText7Paragraph.SetTextAlignment(iText.Layout.Properties.TextAlignment.JUSTIFIED);
                    break;
                case TextAlignment.JUSTIFIED_ALL:
                    iText7Paragraph.SetTextAlignment(iText.Layout.Properties.TextAlignment.JUSTIFIED_ALL);
                    break;
                default:
                    iText7Paragraph.SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);
                    break;
            }

            return iText7Paragraph;

        }

        public iText.Layout.Element.Cell ConvertToCell(Models.Data.Cell cell)
        {
            throw new NotImplementedException();
        }

        public iText.Layout.Element.Paragraph ConvertToParagraph(Paragraph paragraph)
        {
            iText.Layout.Element.Paragraph iText7Paragraph = ConvertToIText7Paragraph(paragraph);

            return iText7Paragraph;

        }
    }
}
