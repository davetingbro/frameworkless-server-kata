using System.Net;
using FrameworklessServerKata.Interface;

namespace FrameworklessServerKata.RequestControllers
{
    public class PersonRequestController : IRequestController
    {
        public Response Get(HttpListenerRequest request, PeopleModel peopleModel)
        {
            throw new System.NotImplementedException();
        }

        public Response Create(HttpListenerRequest request, PeopleModel peopleModel)
        {
            throw new System.NotImplementedException();
        }

        public Response Update(HttpListenerRequest request, PeopleModel peopleModel)
        {
            throw new System.NotImplementedException();
        }

        public Response Delete(HttpListenerRequest request, PeopleModel peopleModel)
        {
            throw new System.NotImplementedException();
        }

        public Response Head(HttpListenerRequest request, PeopleModel peopleModel)
        {
            throw new System.NotImplementedException();
        }
    }
}