using System;
using System.Linq;
using System.Text.RegularExpressions;
using FrameworklessServerKata.RequestControllers;

namespace FrameworklessServerKata
{
    public class RoutingTable
    {
        public RequestController GetRequestController(string url, PeopleModel peopleModel)
        {
            return url switch
            {
                "http://localhost:8080/" => new GreetRequestController(peopleModel),
                "http://localhost:8080/people" => new PeopleRequestController(peopleModel),
                _ when Regex.IsMatch(url, @"http://localhost:8080/people/\w+") 
                        => new PersonRequestController(peopleModel),
                _ => throw new ArgumentException("url not found")
            };
        }
    }
}