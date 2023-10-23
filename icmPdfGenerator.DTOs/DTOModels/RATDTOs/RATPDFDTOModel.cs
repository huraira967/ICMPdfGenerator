namespace ICMPdfGenerator.DTOs.DTOModels.RATDTOs
{
    public class RATPDFDTOModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FacilityId { get; set; }
        public ResidentBasicInformation ResidentBasicInformation { get; set; }
    }
}
