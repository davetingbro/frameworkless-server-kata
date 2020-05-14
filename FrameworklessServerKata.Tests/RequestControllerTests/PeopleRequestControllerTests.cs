using System.Collections.Generic;
using System.Linq;
using FrameworklessServerKata.RequestControllers;
using Newtonsoft.Json;
using Xunit;

namespace FrameworklessServerKata.Tests.RequestControllerTests
{
    public class PeopleRequestControllerTests
    {
        private readonly PeopleModel _peopleModel;

        public PeopleRequestControllerTests()
        {
            _peopleModel = new PeopleModel();
            _peopleModel.Add("Michael");
            _peopleModel.Add("Will");
        }
        
        [Fact]
        public void ShouldReturnCorrectResponse_WhenGet()
        {
            var controller = new PeopleRequestController(_peopleModel);

            var result = controller.Get();
            var expected = new Response(200, "David, Michael, Will");

            var resultJson = JsonConvert.SerializeObject(result);
            var expectedJson = JsonConvert.SerializeObject(expected);
            Assert.Equal(expectedJson, resultJson);
        }
        
        [Fact]
        public void PostShouldAddNewPersonToPeople()
        {
            var controller = new PeopleRequestController(_peopleModel);

            controller.Post("John");
            var result = _peopleModel.People.Select(p => p.Name).ToList();
            var expected = new List<string>{"David", "Michael", "Will", "John"};
            
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void PostShouldReturnResponseStatusCode201_IfSuccessfullyAdded()
        {
            var controller = new PeopleRequestController(_peopleModel);

            var result = controller.Post("John");
            
            Assert.Equal(201, result.StatusCode);
        }

        [Fact]
        public void PostShouldReturnResponseStatusCode202IfPersonAlreadyExist()
        {
            var controller = new PeopleRequestController(_peopleModel);

            var result = controller.Post("David");
            
            Assert.Equal(202, result.StatusCode);
        }

        [Fact]
        public void PostShouldReturnResponseStatusCode202IfRequestBodyIsEmpty()
        {
            var controller = new PeopleRequestController(_peopleModel);

            var result = controller.Post("");
            
            Assert.Equal(202, result.StatusCode);
        }

        [Fact]
        public void Post_PeopleListShouldRemainUnchangedIfRespondedWith202()
        {
            var controller = new PeopleRequestController(_peopleModel);
            controller.Post("David");

            var result = _peopleModel.People.Select(p => p.Name).ToList();
            var expected = new List<string>{"David", "Michael", "Will"};
            
            Assert.Equal(expected, result);
        }
    }
}