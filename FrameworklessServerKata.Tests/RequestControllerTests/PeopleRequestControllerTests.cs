using FrameworklessServerKata.Commands;
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
    }
}