using System.Linq;

namespace FrameworklessServerKata.RequestControllers
{
    public class PeopleRequestController : RequestController
    {
        public PeopleRequestController(PeopleModel peopleModel) : base(peopleModel)
        {
        }

        public override Response Get()
        {
            var names = string.Join(", ", PeopleModel.People.Select(p => p.Name));
            return new Response(200, names);
        }

        public override Response Post(string body)
        {
            if (PeopleModel.People.Any(p => p.Name == body) || body == "") 
                return new Response(200);
            PeopleModel.Add(body);
            return new Response(201, body);
        }

        public override Response Put(string body)
        {
            return new Response(405);
        }

        public override Response Delete()
        {
            return new Response(405);
        }
    }
}