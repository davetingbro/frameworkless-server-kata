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
            throw new System.NotImplementedException();
        }

        public override Response Delete()
        {
            throw new System.NotImplementedException();
        }
    }
}