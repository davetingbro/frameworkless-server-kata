using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using FrameworklessServerKata.Commands;
using Newtonsoft.Json;
using Xunit;

namespace FrameworklessServerKata.Tests.CommandTests
{
    public class GetGreetingsCommandTests
    {
        private readonly PeopleModel _peopleModel;

        public GetGreetingsCommandTests()
        {
            _peopleModel = new PeopleModel();
            _peopleModel.Add("Michael");
            _peopleModel.Add("Will");
        }
        
        [Fact]
        public void ShouldReturnCorrectResponseWhenExecuted()
        {
            var command = new GetGreetingsCommand();

            var result = command.Execute(_peopleModel);
            var responseBody =
                $"Hello David, Michael, Will - the time on the server is {DateTime.Now.ToShortTimeString()} on " +
                $"{DateTime.Now.ToLongDateString()}";
            var expected = new Response(responseBody, "200");

            var resultJson = JsonConvert.SerializeObject(result);
            var expectedJson = JsonConvert.SerializeObject(expected);
            Assert.Equal(expectedJson, resultJson);
        }
    }
}