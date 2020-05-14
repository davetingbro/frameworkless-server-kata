using System;
using FrameworklessServerKata.Commands;

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
            var command = new GetPersonCommand(PeopleModel);
            return command.Execute(_personName);
        }

        public override Response Post(string body)
        {
            return new Response(400);
        }

        public override Response Put(string body)
        {
            var person = PeopleModel.Find(_personName);
            if (person == null)
                PeopleModel.Add(_personName);
            else
                person.Name = body;
            return new Response(200);
        }

        public override Response Delete()
        {
            try
            {
                PeopleModel.Delete(_personName);
            }
            catch (ArgumentException)
            {
                return new Response(400);
            }
            return new Response(204);
        }
    }
}