using FrameworklessServerKata.Commands;
using Newtonsoft.Json;
using Xunit;

namespace FrameworklessServerKata.Tests.CommandTests
{
    public class GetPeopleCommandTests
    {
        private readonly PeopleModel _peopleModel;

        public GetPeopleCommandTests()
        {
            _peopleModel = new PeopleModel();
            _peopleModel.Add("Michael");
            _peopleModel.Add("Will");
        }
        
        [Fact]
        public void ShouldReturnCorrectResponseWhenExecuted()
        {
            var command = new GetPeopleCommand();

            var result = command.Execute(_peopleModel);
            var expected = new Response("David, Michael, Will", "200");

            var resultJson = JsonConvert.SerializeObject(result);
            var expectedJson = JsonConvert.SerializeObject(expected);
            Assert.Equal(expectedJson, resultJson);
        }
    }
}