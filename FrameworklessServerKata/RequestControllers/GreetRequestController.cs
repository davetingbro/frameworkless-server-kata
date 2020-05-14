using System;
using System.Linq;
namespace FrameworklessServerKata.RequestControllers
{
    public class GreetRequestController : RequestController
    {
        public GreetRequestController(PeopleModel peopleModel) : base(peopleModel)
        {
        }

        public override Response Get()
        {
            var names = string.Join(", ", PeopleModel.People.Select(p => p.Name));
            var time = DateTime.Now.ToShortTimeString();
            var date = DateTime.Now.ToLongDateString();
            var responseBody = $"Hello {names} - the time on the server is {time} on {date}";
            return new Response(200, responseBody);
        }

        public override Response Post(string body)
        {
            return new Response(400);
        }

        public override Response Put(string body)
        {
            return new Response(400);
        }

        public override Response Delete()
        {
            return new Response(400);
        }
    }
}