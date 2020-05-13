using System;

namespace FrameworklessServerKata.Commands
{
    public class DeletePersonCommand : ICommand
    {
        private readonly PeopleModel _peopleModel;

        public DeletePersonCommand(PeopleModel peopleModel)
        {
            _peopleModel = peopleModel;
        }
        
        public Response Execute(string reqParam = "", string reqBody = "")
        {
            try
            {
                _peopleModel.Delete(reqParam);
            }
            catch (ArgumentException)
            {
                return new Response("400");
            }
            return new Response("204");
        }
    }
}