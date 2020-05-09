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
    }
}