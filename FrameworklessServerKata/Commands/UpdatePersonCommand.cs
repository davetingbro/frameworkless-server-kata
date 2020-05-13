namespace FrameworklessServerKata.Commands
{
    public class UpdatePersonCommand : ICommand
    {
        private readonly string _personName;
        private readonly PeopleModel _peopleModel;

        public UpdatePersonCommand(PeopleModel peopleModel)
        {
            _peopleModel = peopleModel;
        }

        public UpdatePersonCommand(string personName)
        {
            _personName = personName;
        }
        
        public Response Execute(string reqParam="", string reqBody = "")
        {
            var person = _peopleModel.Find(reqParam);
            if (person == null)
                _peopleModel.Add(reqParam);
            else
                person.Name = reqBody;
            return new Response("200");
        }
        
        public Response Execute(PeopleModel peopleModel, string body="")
        {
            var person = peopleModel.Find(_personName);
            if (person == null)
                peopleModel.Add(_personName);
            else
                person.Name = body;
            return new Response("200");
        }
    }
}