using FrameworklessServerKata.Commands;
namespace FrameworklessServerKata.RequestControllers
{
    public class GreetRequestController : RequestController
    {
        public GreetRequestController(PeopleModel peopleModel, string url) : base(peopleModel, url)
        {
        }

        public override Response Get()
        {
            var command = new GetGreetingsCommand(PeopleModel);
            return command.Execute();
        }

        public override Response Post()
        {
            throw new System.NotImplementedException();
        }

        public override Response Put()
        {
            throw new System.NotImplementedException();
        }

        public override Response Delete()
        {
            throw new System.NotImplementedException();
        }
    }
}