using FrameworklessServerKata.Commands;
namespace FrameworklessServerKata.RequestControllers
{
    public class GreetRequestController : RequestController
    {
        public GreetRequestController(PeopleModel peopleModel) : base(peopleModel)
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