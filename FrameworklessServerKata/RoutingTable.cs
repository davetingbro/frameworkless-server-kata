using System;
using FrameworklessServerKata.Interface;
using FrameworklessServerKata.RequestControllers;

namespace FrameworklessServerKata
{
    public class RoutingTable
    {
        public IRequestController GetRequestController(string url)
        {
            return url switch
            {
                "http://localhost:8080/" => new GreetRequestController(),
                _ => throw new ArgumentException("url not found")
            };
        }
    }
}