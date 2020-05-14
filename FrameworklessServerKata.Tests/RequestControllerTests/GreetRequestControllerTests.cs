using System;
using FrameworklessServerKata.RequestControllers;
using Newtonsoft.Json;
using Xunit;

namespace FrameworklessServerKata.Tests.RequestControllerTests
{
    public class GreetRequestControllerTests
    {
        private readonly PeopleModel _peopleModel;

        public GreetRequestControllerTests()
        {
            _peopleModel = new PeopleModel();
            _peopleModel.Add("Michael");
            _peopleModel.Add("Will");
        }
        
        [Fact]
        public void ShouldReturnCorrectResponseWhenExecuted_GetRequest()
        {
            var controller = new GreetRequestController(_peopleModel);

            var result = controller.Get();
            var responseBody =
                $"Hello David, Michael, Will - the time on the server is {DateTime.Now.ToShortTimeString()} on " +
                $"{DateTime.Now.ToLongDateString()}";
            var expected = new Response(200, responseBody);

            var resultJson = JsonConvert.SerializeObject(result);
            var expectedJson = JsonConvert.SerializeObject(expected);
            Assert.Equal(expectedJson, resultJson);
        }

        [Fact]
        public void PostShouldReturnResponseWithStatusCode400()
        {
            var controller = new GreetRequestController(_peopleModel);
            var result = controller.Post("fake_body");
            Assert.Equal(400, result.StatusCode);
        }
        
        [Fact]
        public void PutShouldReturnResponseWithStatusCode400()
        {
            var controller = new GreetRequestController(_peopleModel);
            var result = controller.Put("fake_body");
            Assert.Equal(400, result.StatusCode);
        }
        
        [Fact]
        public void DeleteShouldReturnResponseWithStatusCode400()
        {
            var controller = new GreetRequestController(_peopleModel);
            var result = controller.Delete();
            Assert.Equal(400, result.StatusCode);
        }
    }
}