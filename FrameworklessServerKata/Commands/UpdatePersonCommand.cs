namespace FrameworklessServerKata.Commands
{
    public class UpdatePersonCommand : ICommand
    {
        private readonly string _personName;

        public UpdatePersonCommand(string personName)
        {
            _personName = personName;
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