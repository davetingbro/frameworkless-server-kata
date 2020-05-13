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
            var command = new GetPeopleCommand(_peopleModel);

            var result = command.Execute();
            var expected = new Response("200", "David, Michael, Will");

            var resultJson = JsonConvert.SerializeObject(result);
            var expectedJson = JsonConvert.SerializeObject(expected);
            Assert.Equal(expectedJson, resultJson);
        }
    }
}