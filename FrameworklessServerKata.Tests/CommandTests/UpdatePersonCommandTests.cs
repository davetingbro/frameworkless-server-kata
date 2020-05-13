using System.Collections.Generic;
using System.Linq;
using FrameworklessServerKata.Commands;
using Newtonsoft.Json;
using Xunit;

namespace FrameworklessServerKata.Tests.CommandTests
{
    public class UpdatePersonCommandTests
    {
        private readonly PeopleModel _peopleModel;

        public UpdatePersonCommandTests()
        {
            _peopleModel = new PeopleModel();
            _peopleModel.Add("Michael");
            _peopleModel.Add("Will");
        }

        [Fact]
        public void ShouldReturnResponseWithStatusCode200()
        {
            var command = new UpdatePersonCommand("Michael");

            var result = command.Execute(_peopleModel, "George");
            var expected = new Response("200");

            var resultJson = JsonConvert.SerializeObject(result);
            var expectedJson = JsonConvert.SerializeObject(expected);
            Assert.Equal(expectedJson, resultJson);
        }

        [Fact]
        public void ShouldUpdatePersonNameToGivenName()
        {
            var command = new UpdatePersonCommand("Michael");

            command.Execute(_peopleModel, "George");
            var result = _peopleModel.People.Select(p => p.Name).ToList();
            var expected = new List<string>{"David", "George", "Will"};
            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldCreateNewPersonIfPersonNotInPeople()
        {
            var command = new UpdatePersonCommand("John");

            command.Execute(_peopleModel);
            var result = _peopleModel.People.Select(p => p.Name).ToList();
            var expected = new List<string>{"David", "Michael", "Will", "John"};
            
            Assert.Equal(expected, result);
        }
    }
}