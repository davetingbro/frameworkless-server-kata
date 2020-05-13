namespace FrameworklessServerKata.Commands
{
    public class GetPersonCommand : ICommand
    {
        private readonly PeopleModel _peopleModel;

        public GetPersonCommand(PeopleModel peopleModel)
        {
            _peopleModel = peopleModel;
        }

        public Response Execute(string urlPersonSegment = "", string requestBody = "")
        {
            var person = _peopleModel.Find(urlPersonSegment);
            return new Response(200, person.Name);
        }
    }
}