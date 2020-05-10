using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using FrameworklessServerKata.Interface;
using FrameworklessServerKata.RequestControllers;

namespace FrameworklessServerKata
{
    public class RoutingTable
    {
        public IRequestController GetRequestController(string url, List<Person> people)
        {
            return url switch
            {
                "http://localhost:8080/" => new GreetRequestController(),
                "http://localhost:8080/people" => new PeopleRequestController(),
                _ when Regex.IsMatch(url, @"http://localhost:8080/people/\w+") 
                        => GetPersonRequestController(url, people),
                _ => throw new ArgumentException("url not found")
            };
        }

        private IRequestController GetPersonRequestController(string url, List<Person> people)
        {
            var personUrls = people.Select(p 
                => $"http://localhost:8080/people/{p.Name.ToLower()}");
            return personUrls.Contains(url)
                ? new PersonRequestController()
                : throw new ArgumentException("url not found");
        }
    }
}