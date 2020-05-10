namespace FrameworklessServerKata
{
    public class Response
    {
        public string Message { get; }
        public string StatusCode { get; }

        public Response(string message, string statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }
    }
}