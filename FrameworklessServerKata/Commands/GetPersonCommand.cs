namespace FrameworklessServerKata.Commands
{
    public class GetPersonCommand : ICommand
    {
        private readonly string _personName;
        private readonly PeopleModel _peopleModel;

        public GetPersonCommand(PeopleModel peopleModel)
        {
            _peopleModel = peopleModel;
        }

        public GetPersonCommand(string personName)
        {
            _personName = personName;
        }
        
        public Response Execute(string reqParam="", string reqBody = "")
        {
            var person = _peopleModel.Find(reqParam);
            return new Response("200", person.Name);
        }

        public Response Execute(PeopleModel peopleModel, string body="")
        {
            var person = peopleModel.Find(_personName);
            return new Response("200", person.Name);
        }
    }
}