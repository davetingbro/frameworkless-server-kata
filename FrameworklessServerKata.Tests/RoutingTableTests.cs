using System;
using System.Collections.Generic;
using FrameworklessServerKata.RequestControllers;
using Xunit;

namespace FrameworklessServerKata.Tests
{
    public class RoutingTableTests
    {
        private readonly RoutingTable _routingTable;
        private readonly List<Person> _people;

        public RoutingTableTests()
        {
            _routingTable = new RoutingTable();
            _people = new List<Person> {new Person("David"), new Person("Michael"), new Person("Will")};
        }
        
        [Theory]
        [InlineData("http://localhost:8080/", typeof(GreetRequestController))]
        [InlineData("http://localhost:8080/people", typeof(PeopleRequestController))]
        [InlineData("http://localhost:8080/people/david", typeof(PersonRequestController))]
        public void ShouldReturnCorrectRequestController_WhenGivenValidUrl(string url, Type expectedType)
        {
            var result = _routingTable.GetRequestController(url, _people);

            Assert.IsType(expectedType, result);
        }
    }
}