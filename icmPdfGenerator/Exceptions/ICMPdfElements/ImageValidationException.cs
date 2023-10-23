namespace ICMPdfGenerator.Exceptions.ICMPdfElements
{
    public class ImageValidationException : Xeptions.Xeption
    {
        public ImageValidationException(Exception innerException)
            :base(message:"Image is null, null image can not be added to Document",
                 innerException: innerException)
        {
            
        }
        public ImageValidationException(string message, Exception innerException)
            :base (message:message, innerException:innerException)
        {
            
        }
    }
}
