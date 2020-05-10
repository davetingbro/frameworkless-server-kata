using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xunit;

namespace FrameworklessServerKata.Tests
{
    public class PeopleModelTests
    {
        private readonly PeopleModel _peopleModel;

        public PeopleModelTests()
        {
            _peopleModel = new PeopleModel();
        }

        [Fact]
        public void ShouldHavePersonNamedDavidByDefault_WhenInstantiated()
        {
            var result = _peopleModel.People;

            var resultJson = JsonConvert.SerializeObject(result);
            var expectedJson = JsonConvert.SerializeObject(new List<Person> {new Person("David")});
            Assert.Equal(expectedJson, resultJson);
        }

        [Fact]
        public void ShouldAddGivenPersonToPeopleList()
        {
            _peopleModel.Add(new Person("Michael"));
            var result = _peopleModel.People;
            var expected = new List<Person>
            {
                new Person("David"), new Person("Michael")
            };

            var resultJson = JsonConvert.SerializeObject(result);
            var expectedJson = JsonConvert.SerializeObject(expected);
            Assert.Equal(expectedJson, resultJson);
        }
        
        [Fact]
        public void ShouldDeletePersonFromList_GivenName()
        {
            _peopleModel.Add(new Person("Michael"));
            _peopleModel.Add(new Person("Will"));

            _peopleModel.Delete("Will");
            var expected = new List<Person>
            {
                new Person("David"), new Person("Michael")
            };

            var resultJson = JsonConvert.SerializeObject(_peopleModel.People);
            var expectedJson = JsonConvert.SerializeObject(expected);
            Assert.Equal(expectedJson, resultJson);
        }
        
                
        [Fact]
        public void ShouldThrowArgumentException_WhenTryToDeleteDavid()
        {
            Assert.Throws<ArgumentException>(() => _peopleModel.Delete("David"));
        }

        [Fact]
        public void ShouldReturnCorrectPerson_GivenName()
        {
            _peopleModel.Add(new Person("Michael"));
            _peopleModel.Add(new Person("Will"));

            var result = _peopleModel.Find("Will");

            var resultJson = JsonConvert.SerializeObject(result);
            var expectedJson = JsonConvert.SerializeObject(new Person("Will"));
            Assert.Equal(expectedJson, resultJson);
        }
    }
}