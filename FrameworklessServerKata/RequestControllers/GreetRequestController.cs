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

        public override Response Post(string body)
        {
            return new Response(400);
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