namespace FrameworklessServerKata
{
    public class Response
    {
        public string Body { get; }
        public int StatusCode { get; }

        public Response(int statusCode, string body = "")
        {
            Body = body;
            StatusCode = statusCode;
        }
    }
}