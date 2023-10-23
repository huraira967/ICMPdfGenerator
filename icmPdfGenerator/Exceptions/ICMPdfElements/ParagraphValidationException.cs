namespace ICMPdfGenerator.Exceptions.ICMPdfElements
{
    public class ParagraphValidationException : Xeptions.Xeption
    {
        public ParagraphValidationException(Exception innerException)
                : base(
                      message:"Paragraph is null, null paragraph can not be added",
                      innerException: innerException)
        {
            
        }
        public ParagraphValidationException(string message, Exception innerException)
            :base(message:message, innerException: innerException)
        {
            
        }
    }
}
