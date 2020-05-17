using System;

namespace FrameworklessServerKata.RequestControllers
{
    public class PersonRequestController : RequestController
    {
        private readonly string _personName;
        public PersonRequestController(PeopleModel peopleModel, string personName) : base(peopleModel)
        {
            _personName = personName;
        }

        public override Response Get()
        {
            return new Response(403);
        }

        public override Response Post(string body)
        {
            return new Response(405);
        }

        public override Response Put(string body)
        {
            var person = PeopleModel.Find(_personName);
            if (person == null)
                return new Response(404);
            person.Name = body;
            var response = new Response(301);
            response.Headers["Location"] = $"http://localhost:8080/people/{body}";
            return response;
        }

        public override Response Delete()
        {
            try
            {
                PeopleModel.Delete(_personName);
            }
            catch (ArgumentException)
            {
                return new Response(403);
            }
            return new Response(204);
        }
    }
}