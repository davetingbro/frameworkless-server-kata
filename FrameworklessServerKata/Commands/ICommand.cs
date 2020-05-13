namespace FrameworklessServerKata.Commands
{
    public interface ICommand
    {
        Response Execute(string reqParam="", string reqBody = "");
    }
}