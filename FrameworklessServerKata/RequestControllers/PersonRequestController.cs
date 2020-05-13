namespace FrameworklessServerKata.RequestControllers
{
    public class PersonRequestController : RequestController
    {
        public PersonRequestController(PeopleModel peopleModel, string url) : base(peopleModel, url)
        {
        }

        public override Response Get()
        {
            throw new System.NotImplementedException();
        }

        public override Response Post()
        {
            return new Response(400);
        }

        public override Response Put()
        {
            throw new System.NotImplementedException();
        }

        public override Response Delete()
        {
            throw new System.NotImplementedException();
        }
    }
}