using System.Net;

namespace FrameworklessServerKata.Interface
{
    public interface IRequestController
    {
        void Get(HttpListenerRequest request);
        void Create(HttpListenerRequest request);
        void Update(HttpListenerRequest request);
        void Delete(HttpListenerRequest request);
        void Head(HttpListenerRequest request);
    }
}