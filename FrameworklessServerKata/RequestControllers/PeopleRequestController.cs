using System.Net;
using FrameworklessServerKata.Commands;

namespace FrameworklessServerKata.RequestControllers
{
    public class PeopleRequestController : RequestController
    {
        public PeopleRequestController(PeopleModel peopleModel) : base(peopleModel)
        {
        }

        public override Response Get()
        {
            var command = new GetPeopleCommand(PeopleModel);
            return command.Execute();
        }

        public override Response Post(string body)
        {
            var command = new AddToPeopleCommand(PeopleModel);
            return command.Execute(requestBody: body);
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