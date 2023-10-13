using ICMPdfGenerator.DTOs.DTOModels.RATDTOs;
using ICMPdfGenerator.Models.Data;
using ICMPdfGenerator.Models.Data.CellElements;

namespace ICMPdfGenerator.PdfTemplates.PdfModuleTemplates.RAT.TemplateParts
{
    public class RATResidentBasicInformation : IRATTemplatePart
    {
        private static ICellElement GetLabelCell(string label)
        {
            var text = new TextSegment(label);
            text.FontSize = Configuration.Enums.FontSize.Px18;
            text.FontStyle = Configuration.Enums.FontStyle.Bold;
            text.FontWeight = Configuration.Enums.FontWeight.MEDIUM;
            return new Cell().Add(new Paragraph().Add(text));
        }
        private static ICellElement GetValueCell(string label)
        {
            var text = new TextSegment(label);
            text.FontSize = Configuration.Enums.FontSize.Px9;
            text.FontStyle = Configuration.Enums.FontStyle.Italic;
            text.FontWeight = Configuration.Enums.FontWeight.NORMAL;
            return new Cell().Add(new Paragraph().Add(text));
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

            return ResidentBasicnInfo;
        }
        public Table GetBasicResidentInformation(ResidentBasicInformation residentBasicInformation)
        {
           return BuildResidentBasicInformationTable(residentBasicInformation);
        }
    }
}
