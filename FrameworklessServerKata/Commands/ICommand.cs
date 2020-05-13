namespace FrameworklessServerKata.Commands
{
    public interface ICommand
    {
        Response Execute(string urlPersonSegment = "", string requestBody = "");
    }
}