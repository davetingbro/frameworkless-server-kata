namespace FrameworklessServerKata.Commands
{
    public class UpdatePersonCommand : ICommand
    {
        private readonly PeopleModel _peopleModel;

        public UpdatePersonCommand(PeopleModel peopleModel)
        {
            _peopleModel = peopleModel;
        }

        public Response Execute(string urlPersonSegment = "", string requestBody = "")
        {
            var person = _peopleModel.Find(urlPersonSegment);
            if (person == null)
                _peopleModel.Add(urlPersonSegment);
            else
                person.Name = requestBody;
            return new Response(200);
        }
    }
}