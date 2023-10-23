using ICMPdfGenerator.DTOs.DTOModels.RATDTOs;
using ICMPdfGenerator.ICMProperties.Enums;
using ICMPdfGenerator.Models.ICMPdfElements;
using ICMPdfGenerator.Models.ICMPdfElements.CellElements;
using ICMPdfGenerator.Models.ICMPdfLayout.Elements;

namespace ICMPdfGenerator.PdfTemplates.PdfModuleTemplates.RAT.TemplateParts
{
    public class RATResidentBasicInformation : IRATTemplatePart
    {
        private static Cell GetLabelCell(string label)
        {
            var text = new TextSegment(label);
            text.Styles.FontSize = FontSize.Px18;
            text.Styles.FontStyle = ICMProperties.Enums.FontStyle.BoldItalic;
            text.Styles.Underline = true;
            var c = new Cell().Add(new Paragraph().Add(text));
            var border = new Models.ICMPdfLayout.Elements.Border(-1, borderType: ICMProperties.Enums.BorderType.None, borderRadius: new UnitValue(10, true, false));
            c.Styles.Border = border;
            return c;
        }
        private static Cell GetValueCell(string label)
        {
            var text = new TextSegment(label);
            text.Styles.FontSize = FontSize.Px9;

            text.Styles.FontStyle = FontStyle.Italic;

            var c = new Cell().Add(new Paragraph().Add(text));
            var border = new Border(border: -1, borderType: BorderType.None, borderRadius: new UnitValue(10, true, false));

            c.Styles.Border = border;
            return c;
        }
        private static Cell GetImageCell()
        {
            Image image = new Image("D:\\ICMPdfApplication\\icmPdfGenerator\\Assests\\images.jpg");
            return new Cell().Add(image);

        }
        private Table BuildResidentBasicInformationTable(ResidentBasicInformation residentBasicInformation)
        {
            Table ResidentBasicnInfo = new Table(2);

            ResidentBasicnInfo.Add(GetLabelCell("Name"));
            ResidentBasicnInfo.Add(GetValueCell(residentBasicInformation.Name));
            ResidentBasicnInfo.Add(GetLabelCell("Age"));
            ResidentBasicnInfo.Add(GetValueCell(residentBasicInformation.Age.ToString()));
            ResidentBasicnInfo.Add(GetLabelCell("Gender"));
            ResidentBasicnInfo.Add(GetValueCell(residentBasicInformation.Gender));
            ResidentBasicnInfo.Add(GetLabelCell("Language"));
            ResidentBasicnInfo.Add(GetValueCell(residentBasicInformation.Language));
            ResidentBasicnInfo.Add(GetLabelCell("Date of Birth"));
            ResidentBasicnInfo.Add(GetValueCell(residentBasicInformation.DateOfBirth.ToShortDateString()));
            ResidentBasicnInfo.Add(GetLabelCell("Nationality"));
            ResidentBasicnInfo.Add(GetValueCell(residentBasicInformation.Nationality));
            ResidentBasicnInfo.Add(GetLabelCell("Image"));
            ResidentBasicnInfo.Add(GetImageCell());

            ResidentBasicnInfo.Styles.Border = new Border(borderType: BorderType.None, borderRadius: new UnitValue(10, true, false));

            return ResidentBasicnInfo;
        }
        public Table GetBasicResidentInformation(ResidentBasicInformation residentBasicInformation)
        {
            return BuildResidentBasicInformationTable(residentBasicInformation);
        }
    }
}

