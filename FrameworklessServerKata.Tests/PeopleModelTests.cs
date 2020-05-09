using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xunit;

namespace FrameworklessServerKata.Tests
{
    public class PeopleModelTests
    {
        [Fact]
        public void ShouldHavePersonNamedDavidByDefault_WhenInstantiated()
        {
            var peopleModel = new PeopleModel();

            var result = peopleModel.People;

            var resultJson = JsonConvert.SerializeObject(result);
            var expectedJson = JsonConvert.SerializeObject(new List<Person> {new Person("David")});
            Assert.Equal(expectedJson, resultJson);
        }

        [Fact]
        public void ShouldAddGivenPersonToPeopleList()
        {
            var peopleModel = new PeopleModel();

            peopleModel.Add(new Person("Michael"));
            var result = peopleModel.People;
            var expected = new List<Person>
            {
                new Person("David"), new Person("Michael")
            };

            var resultJson = JsonConvert.SerializeObject(result);
            var expectedJson = JsonConvert.SerializeObject(expected);
            Assert.Equal(expectedJson, resultJson);
        }
    }
}