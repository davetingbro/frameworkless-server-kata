using System;
using System.Collections.Generic;
using System.Linq;

namespace FrameworklessServerKata.Commands
{
    public class GetGreetingsCommand : ICommand
    {
        public Response Execute(PeopleModel peopleModel, string body = "")
        {
            var responseBody = GetResponseBody(peopleModel.People);
            return new Response(responseBody, "200");
        }

        private static string GetResponseBody(List<Person> people)
        {
            var names = string.Join(", ", people.Select(p => p.Name));
            var time = DateTime.Now.ToShortTimeString();
            var date = DateTime.Now.ToLongDateString();

            return $"Hello {names} - the time on the server is {time} on {date}";
        }
    }
}