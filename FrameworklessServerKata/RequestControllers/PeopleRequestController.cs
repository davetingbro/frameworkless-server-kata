using FrameworklessServerKata.Commands;

namespace FrameworklessServerKata.RequestControllers
{
    public class PeopleRequestController : RequestController
    {
        public PeopleRequestController(PeopleModel peopleModel, string url) : base(peopleModel, url)
        {
        }

        public override Response Get()
        {
            var command = new GetPeopleCommand(PeopleModel);
            return command.Execute();
        }

        public override Response Post()
        {
            throw new System.NotImplementedException();
        }

        public override Response Put()
        {
            return new Response(400);
        }

        public override Response Delete()
        {
            return new Response(400);
        }
    }
}