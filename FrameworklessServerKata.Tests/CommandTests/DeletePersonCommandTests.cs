using System.Collections.Generic;
using System.Linq;
using FrameworklessServerKata.Commands;
using Newtonsoft.Json;
using Xunit;

namespace FrameworklessServerKata.Tests.CommandTests
{
    public class DeletePersonCommandTests
    {
        private readonly PeopleModel _peopleModel;

        public DeletePersonCommandTests()
        {
            _peopleModel = new PeopleModel();
            _peopleModel.Add("Michael");
            _peopleModel.Add("Will");
        }

        [Fact]
        public void ShouldReturnResponseWithStatusCode204()
        {
            var command = new DeletePersonCommand(_peopleModel);

            var result = command.Execute("Michael");
            var expected = new Response(204);

            var resultJson = JsonConvert.SerializeObject(result);
            var expectedJson = JsonConvert.SerializeObject(expected);
            Assert.Equal(expectedJson, resultJson);
        }
        
        [Fact]
        public void ShouldRemovePersonFromPeople()
        {
            var command = new DeletePersonCommand(_peopleModel);
            
            command.Execute("Michael");
            var result = _peopleModel.People.Select(p => p.Name).ToList();
            var expected = new List<string>{"David", "Will"};
            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldReturnResponseWithStatusCode400_IfDeletingWorldOwner()
        {
            var command = new DeletePersonCommand(_peopleModel);

            var response = command.Execute("David");
            
            Assert.Equal(400, response.StatusCode);
        }
    }
}