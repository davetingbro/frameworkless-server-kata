using System.Net;

namespace FrameworklessServerKata.Interface
{
    public interface IRequestController
    {
        Response Get(HttpListenerRequest request, PeopleModel peopleModel);
        Response Create(HttpListenerRequest request, PeopleModel peopleModel);
        Response Update(HttpListenerRequest request, PeopleModel peopleModel);
        Response Delete(HttpListenerRequest request, PeopleModel peopleModel);
        Response Head(HttpListenerRequest request, PeopleModel peopleModel);
    }
}