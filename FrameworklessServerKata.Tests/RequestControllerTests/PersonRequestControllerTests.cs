using System.Collections.Generic;
using System.Linq;
using FrameworklessServerKata.RequestControllers;
using Newtonsoft.Json;
using Xunit;

namespace FrameworklessServerKata.Tests.RequestControllerTests
{
    public class PersonRequestControllerTests
    {
        private readonly PeopleModel _peopleModel;

        public PersonRequestControllerTests()
        {
            _peopleModel = new PeopleModel();
            _peopleModel.Add("Michael");
            _peopleModel.Add("Will");
        }
        
        [Fact]
        public void Get_ShouldReturnCorrectResponse()
        {
            var controller = new PersonRequestController(_peopleModel, "Michael");

            var result = controller.Get();
            var expected = new Response(200, "Michael");

            var resultJson = JsonConvert.SerializeObject(result);
            var expectedJson = JsonConvert.SerializeObject(expected);
            Assert.Equal(expectedJson, resultJson);
        }
        
        [Fact]
        public void Delete_ShouldReturnResponseWithStatusCode204()
        {
            var controller = new PersonRequestController(_peopleModel, "Michael");

            var result = controller.Delete();
            
            Assert.Equal(204, result.StatusCode);
        }
        
        [Fact]
        public void Delete_ShouldRemovePersonFromPeople()
        {
            var controller = new PersonRequestController(_peopleModel, "Michael");
            
            controller.Delete();
            var result = _peopleModel.People.Select(p => p.Name).ToList();
            var expected = new List<string>{"David", "Will"};
            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Delete_ShouldReturnResponseWithStatusCode400_IfDeletingWorldOwner()
        {
            var controller = new PersonRequestController(_peopleModel, "David");

            var response = controller.Delete();
            
            Assert.Equal(400, response.StatusCode);
        }
        
        [Fact]
        public void Put_ShouldReturnResponseWithStatusCode200()
        {
            var controller = new PersonRequestController(_peopleModel, "Michael");

            var result = controller.Put("George");
            var expected = new Response(200);

            var resultJson = JsonConvert.SerializeObject(result);
            var expectedJson = JsonConvert.SerializeObject(expected);
            Assert.Equal(expectedJson, resultJson);
        }

        [Fact]
        public void Put_ShouldUpdatePersonNameToGivenName()
        {
            var controller = new PersonRequestController(_peopleModel, "Michael");

            controller.Put("George");
            var result = _peopleModel.People.Select(p => p.Name).ToList();
            var expected = new List<string>{"David", "George", "Will"};
            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Put_ShouldCreateNewPersonIfPersonNotInPeople()
        {
            var controller = new PersonRequestController(_peopleModel, "John");

            controller.Put("");
            var result = _peopleModel.People.Select(p => p.Name).ToList();
            var expected = new List<string>{"David", "Michael", "Will", "John"};
            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Post_ShouldReturnResponseStatusCode400()
        {
            var controller = new PersonRequestController(_peopleModel, "Michael");
            var result = controller.Post("fake_body");
            Assert.Equal(400, result.StatusCode);
        }
    }
}