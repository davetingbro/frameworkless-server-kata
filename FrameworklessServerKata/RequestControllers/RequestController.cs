using FrameworklessServerKata.Commands;

namespace FrameworklessServerKata.RequestControllers
{
    public abstract class RequestController
    {
        protected readonly PeopleModel PeopleModel;
        protected readonly string Url;

        protected RequestController(PeopleModel peopleModel, string url)
        {
            PeopleModel = peopleModel;
            Url = url;
        }

        public abstract Response Get();
        public abstract Response Post(string body);
        public abstract Response Put();
        public abstract Response Delete();
    }
}