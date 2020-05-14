using System;
using System.IO;
using System.Net;
using FrameworklessServerKata.RequestControllers;

namespace FrameworklessServerKata
{
    public class Server
    {
        private readonly HttpListener _listener = new HttpListener();
        private readonly RoutingTable _routingTable = new RoutingTable();
        private readonly PeopleModel _peopleModel = new PeopleModel();

        public Server()
        {
            _listener.Prefixes.Add("http://localhost:8080/");
        }

        public void Start()
        {
            _listener.Start();
            while (true)
            {
                var context = _listener.GetContext();
                var httpRequest = context.Request;

                Console.WriteLine($"{httpRequest.HttpMethod} {httpRequest.Url}");
                var response = CreateResponse(httpRequest);
                SetHttpListenerResponse(context, response);
            }
        }

        private Response CreateResponse(HttpListenerRequest request)
        {
            try
            {
                var controller = _routingTable.GetRequestController(request.Url.AbsoluteUri, _peopleModel);
                return ExecuteRequestMethod(request, controller);
            }
            catch (ArgumentException)
            {
                return new Response(404);
            }
        }

        private static Response ExecuteRequestMethod(HttpListenerRequest request, RequestController controller)
        {
            var requestMethod = $"{request.HttpMethod}";
            var body = new StreamReader(request.InputStream).ReadToEnd();
            return requestMethod switch
            {
                "GET" => controller.Get(),
                "POST" => controller.Post(body),
                "PUT" => controller.Put(body),
                "DELETE" => controller.Delete(),
                _ => new Response(404)
            };
        }

        private static void SetHttpListenerResponse(HttpListenerContext context, Response response)
        {
            var buffer = System.Text.Encoding.UTF8.GetBytes(response.Body);
            var httpResponse = context.Response;
            httpResponse.StatusCode = response.StatusCode;
            httpResponse.ContentLength64 = buffer.Length;
            httpResponse.OutputStream.Write(buffer, 0, buffer.Length);
            httpResponse.OutputStream.Close();
        }

    }
}