namespace ICMPdfGenerator.Exceptions.ICMPdfElements
{
    public class CellValidationException : Xeptions.Xeption
    {
        public CellValidationException(Exception innerException)
                : base(
                      message:"Cell is null, null Cell can not be added to Document",
                      innerException: innerException)
        { }
        public CellValidationException(string message, Exception innerException):
            base(message, innerException)
        { }
        
    }
}
