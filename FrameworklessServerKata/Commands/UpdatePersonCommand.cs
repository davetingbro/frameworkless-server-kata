namespace FrameworklessServerKata.Commands
{
    public class UpdatePersonCommand : ICommand
    {
        private readonly PeopleModel _peopleModel;

        public UpdatePersonCommand(PeopleModel peopleModel)
        {
            _peopleModel = peopleModel;
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
    }
}