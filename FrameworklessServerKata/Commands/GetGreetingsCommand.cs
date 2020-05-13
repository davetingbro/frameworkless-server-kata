using System;
using System.Collections.Generic;
using System.Linq;

namespace FrameworklessServerKata.Commands
{
    public class GetGreetingsCommand : ICommand
    {
        private readonly PeopleModel _peopleModel;

        public GetGreetingsCommand(PeopleModel peopleModel)
        {
            _peopleModel = peopleModel;
        }

        public Response Execute(string reqParam="", string reqBody = "")
        {
            var responseBody = GetResponseBody(_peopleModel.People);
            return new Response("200", responseBody);
        }

        public Response Execute(PeopleModel peopleModel, string body = "")
        {
            var responseBody = GetResponseBody(peopleModel.People);
            return new Response("200", responseBody);
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