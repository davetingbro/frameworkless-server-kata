using FrameworklessServerKata.Commands;
using Newtonsoft.Json;
using Xunit;

namespace FrameworklessServerKata.Tests.CommandTests
{
    public class GetPersonCommandTests
    {
        private readonly PeopleModel _peopleModel;

        public GetPersonCommandTests()
        {
            _peopleModel = new PeopleModel();
            _peopleModel.Add("Michael");
            _peopleModel.Add("Will");
        }
        
        [Fact]
        public void ShouldReturnCorrectResponseWhenExecuted()
        {
            var command = new GetPersonCommand("Michael");

            var result = command.Execute(_peopleModel);
            var expected = new Response("200", "Michael");

            var resultJson = JsonConvert.SerializeObject(result);
            var expectedJson = JsonConvert.SerializeObject(expected);
            Assert.Equal(expectedJson, resultJson);
        }
    }
}