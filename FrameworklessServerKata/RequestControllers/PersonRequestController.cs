namespace FrameworklessServerKata.RequestControllers
{
    public class PersonRequestController : RequestController
    {
        public PersonRequestController(PeopleModel peopleModel) : base(peopleModel)
        {
        }

        public override Response Get()
        {
            throw new System.NotImplementedException();
        }

        public override Response Post(string body)
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