namespace ICMPdfGenerator.Exceptions.DependencyResolveExceptions
{
    public class RequestBodyValidationException : Xeptions.Xeption
    {
        public RequestBodyValidationException(Exception innerException): base(
            message: "Request body is null, send request body in payload in POST request",
            innerException: innerException)
        {
        }
        public RequestBodyValidationException(string message, Exception innerException) : base(
            message: message,
            innerException: innerException)
        {
        }
    }
}
