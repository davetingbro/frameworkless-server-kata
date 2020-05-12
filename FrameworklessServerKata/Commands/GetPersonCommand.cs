namespace FrameworklessServerKata.Commands
{
    public class GetPersonCommand : ICommand
    {
        private readonly string _personName;

        public GetPersonCommand(string personName)
        {
            _personName = personName;
        }

        public Response Execute(PeopleModel peopleModel)
        {
            var person = peopleModel.Find(_personName);
            return new Response(person.Name, "200");
        }
    }
}