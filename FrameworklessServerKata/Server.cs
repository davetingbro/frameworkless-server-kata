using System;
using System.Net;

namespace FrameworklessServerKata
{
    public class Server
    {
        private readonly HttpListener _listener;

        public Server()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://localhost:8080/");
        }

        public void Start()
        {
            _listener.Start();
            while (true)
            {
                var context = _listener.GetContext();
                Console.WriteLine($"{context.Request.HttpMethod} {context.Request.Url}");
                var time = DateTime.Now.ToShortTimeString();
                var date = DateTime.Now.ToLongDateString();
                var buffer = System.Text.Encoding.UTF8.GetBytes(
                    $"Hello David - the time on the server is {time} on {date}");
                context.Response.ContentLength64 = buffer.Length;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            }
        }

    }
}