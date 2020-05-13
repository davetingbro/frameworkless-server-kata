using System.Linq;

namespace FrameworklessServerKata.Commands
{
    public class GetPeopleCommand : ICommand
    {
        private readonly PeopleModel _peopleModel;

        public GetPeopleCommand(PeopleModel peopleModel)
        {
            _peopleModel = peopleModel;
        }

        public Response Execute(string reqParam="", string reqBody = "")
        {
            var names = string.Join(", ", _peopleModel.People.Select(p => p.Name));
            return new Response("200", names);
        }
    }
}