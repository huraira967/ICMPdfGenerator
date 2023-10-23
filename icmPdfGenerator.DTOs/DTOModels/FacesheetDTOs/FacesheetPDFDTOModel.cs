namespace ICMPdfGenerator.DTOs.DTOModels.FacesheetDTOs
{
    public class FacesheetPDFDTOModel
    {
        public int Id { get; set; }
        public string ProgramName { get; set; }
        public string LocationAddress { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string LogoImage { get; set; }
        public string ResidentImage { get; set; }
        public string DocumentTitle { get; set; }

        public int UserId { get; set; }
        public int FacilityId { get; set; }
        public string Name { get; set; }
    }
}
