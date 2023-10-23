namespace ICMPdfGenerator.Exceptions.ICMPdfElements
{
    public class TableValidationException : Xeptions.Xeption
    {
        public TableValidationException(Exception innerException):
            base(
                message:"Table is null, null table can not be added to Document",
                innerException: innerException )
        {
        }
        public TableValidationException(string message, Exception innerException)
            : base(message: message, innerException: innerException) 
        {
        }
    }
}
