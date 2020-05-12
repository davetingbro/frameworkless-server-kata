using System.Linq;

namespace FrameworklessServerKata.Commands
{
    public class GetPeopleCommand : ICommand
    {
        public Response Execute(PeopleModel peopleModel)
        {
            var names = string.Join(", ", peopleModel.People.Select(p => p.Name));
            return new Response(names, "200");
        }
    }
}