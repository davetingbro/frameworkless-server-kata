using System.Collections.Generic;
using System.Linq;
using FrameworklessServerKata.Commands;
using Xunit;

namespace FrameworklessServerKata.Tests.CommandTests
{
    public class AddToPeopleCommandTests
    {
        private readonly PeopleModel _peopleModel;

        public AddToPeopleCommandTests()
        {
            _peopleModel = new PeopleModel();
            _peopleModel.Add("Michael");
            _peopleModel.Add("Will");
        }

        [Fact]
        public void ShouldAddNewPersonToPeople()
        {
            var command = new AddToPeopleCommand(_peopleModel);

            command.Execute(requestBody: "John");
            var result = _peopleModel.People.Select(p => p.Name).ToList();
            var expected = new List<string>{"David", "Michael", "Will", "John"};
            
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void ShouldReturnResponseStatusCode201_IfSuccessfullyAdded()
        {
            var command = new AddToPeopleCommand(_peopleModel);

            var result = command.Execute(requestBody: "John");
            
            Assert.Equal(201, result.StatusCode);
        }

        [Fact]
        public void ShouldReturnResponseStatusCode202IfPersonAlreadyExist()
        {
            var command = new AddToPeopleCommand(_peopleModel);

            var result = command.Execute(requestBody: "David");
            
            Assert.Equal(202, result.StatusCode);
        }

        [Fact]
        public void ShouldReturnResponseStatusCode202IfRequestBodyIsEmpty()
        {
            var command = new AddToPeopleCommand(_peopleModel);

            var result = command.Execute(requestBody: "");
            
            Assert.Equal(202, result.StatusCode);
        }

        [Fact]
        public void PeopleListShouldRemainUnchangedIfRespondedWith202()
        {
            var command = new AddToPeopleCommand(_peopleModel);
            command.Execute(requestBody: "David");

            var result = _peopleModel.People.Select(p => p.Name).ToList();
            var expected = new List<string>{"David", "Michael", "Will"};
            
            Assert.Equal(expected, result);
        }
        
    }
}