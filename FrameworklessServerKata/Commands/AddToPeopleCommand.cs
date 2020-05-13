using System.Linq;

namespace FrameworklessServerKata.Commands
{
    public class AddToPeopleCommand : ICommand
    {
        private readonly PeopleModel _peopleModel;

        public AddToPeopleCommand(PeopleModel peopleModel)
        {
            _peopleModel = peopleModel;
        }
        
        public Response Execute(string urlPersonSegment = "", string requestBody = "")
        {
            if (_peopleModel.People.Any(p => p.Name == requestBody) || requestBody == "") 
                return new Response(202);
            _peopleModel.Add(requestBody);
            return new Response(201, requestBody);
        }
    }
}