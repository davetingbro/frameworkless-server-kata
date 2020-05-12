namespace FrameworklessServerKata.Commands
{
    public interface ICommand
    {
        Response Execute(PeopleModel peopleModel);
    }
}