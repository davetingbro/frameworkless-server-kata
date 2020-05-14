namespace FrameworklessServerKata.RequestControllers
{
    public abstract class RequestController
    {
        protected readonly PeopleModel PeopleModel;

        protected RequestController(PeopleModel peopleModel)
        {
            PeopleModel = peopleModel;
        }

        public abstract Response Get();
        public abstract Response Post(string body);
        public abstract Response Put(string body);
        public abstract Response Delete();
    }
}