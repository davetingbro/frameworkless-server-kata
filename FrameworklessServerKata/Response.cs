namespace FrameworklessServerKata
{
    public class Response
    {
        public string Body { get; }
        public string StatusCode { get; }

        public Response(string statusCode, string body="")
        {
            Body = body;
            StatusCode = statusCode;
        }
    }
}