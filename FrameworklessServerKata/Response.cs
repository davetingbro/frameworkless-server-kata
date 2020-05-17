using System.Collections.Generic;

namespace FrameworklessServerKata
{
    public class Response
    {
        public string Body { get; }
        public int StatusCode { get; }
        public Dictionary<string, string> Headers { get; }

        public Response(int statusCode, string body = "")
        {
            Body = body;
            StatusCode = statusCode;
            Headers = new Dictionary<string, string>();
        }
    }
}