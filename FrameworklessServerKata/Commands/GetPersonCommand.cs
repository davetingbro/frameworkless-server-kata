namespace FrameworklessServerKata.Commands
{
    public class GetPersonCommand : ICommand
    {
        private readonly PeopleModel _peopleModel;

        public GetPersonCommand(PeopleModel peopleModel)
        {
            _peopleModel = peopleModel;
        }

        public Response Execute(string reqParam="", string reqBody = "")
        {
            var person = _peopleModel.Find(reqParam);
            return new Response("200", person.Name);
        }
    }
}