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
                "http://localhost:8080/" => new GreetRequestController(peopleModel, url),
                "http://localhost:8080/people" => new PeopleRequestController(peopleModel, url),
                _ when Regex.IsMatch(url, @"http://localhost:8080/people/\w+") 
                        => GetPersonRequestController(url, peopleModel),
                _ => throw new ArgumentException("url not found")
            };
        }

        private RequestController GetPersonRequestController(string url, PeopleModel peopleModel)
        {
            var personUrls = peopleModel.People.Select(p 
                => $"http://localhost:8080/people/{p.Name.ToLower()}");
            return personUrls.Contains(url)
                ? new PersonRequestController(peopleModel, url)
                : throw new ArgumentException("url not found");
        }
    }
}