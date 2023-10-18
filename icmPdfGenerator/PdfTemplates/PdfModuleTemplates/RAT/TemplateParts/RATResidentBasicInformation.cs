using ICMPdfGenerator.Configuration.Enums;
using ICMPdfGenerator.DTOs.DTOModels.RATDTOs;
using ICMPdfGenerator.Models.Data;
using ICMPdfGenerator.Models.Data.CellElements;
using ICMPdfGenerator.Models.Layout.Styles;

namespace ICMPdfGenerator.PdfTemplates.PdfModuleTemplates.RAT.TemplateParts
{
    public class RATResidentBasicInformation : IRATTemplatePart
    {
        private static Cell GetLabelCell(string label)
        {
            var text = new TextSegment(label);
            text.FontSize = Configuration.Enums.FontSize.Px18;
            text.FontStyle = Configuration.Enums.FontStyle.Bold;
            text.FontWeight = Configuration.Enums.FontWeight.MEDIUM;
            var c = new Cell().Add(new Paragraph().Add(text));
            var border = new Models.Layout.Styles.Border(-1,borderType: Configuration.Enums.BorderType.None, borderRadius: new UnitValue(10, true, false));
            c.Styles.Border = border;
            return c;
        }
        private static Cell GetValueCell(string label)
        {
            var text = new TextSegment(label);
            text.FontSize = Configuration.Enums.FontSize.Px9;
            text.FontStyle = Configuration.Enums.FontStyle.Italic;
            text.FontWeight = Configuration.Enums.FontWeight.NORMAL;
            var c = new Cell().Add(new Paragraph().Add(text));
            var border = new Models.Layout.Styles.Border(border:-1, borderType: Configuration.Enums.BorderType.None,borderRadius:new UnitValue(10,true,false));
            //border=  border.SetBorderRadius(new UnitValue(100, true, false));
            //border.SetBorderRadius(new Models.Layout.Styles.UnitValue(100, true, false));
            c.Styles.Border = border;
            return c;
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

            ResidentBasicnInfo.Styles.Border = new Border(borderType: BorderType.None, borderRadius: new UnitValue(10,true,false));

            return ResidentBasicnInfo;
        }
        public Table GetBasicResidentInformation(ResidentBasicInformation residentBasicInformation)
        {
           return BuildResidentBasicInformationTable(residentBasicInformation);
        }
    }
}

