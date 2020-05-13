using System;
using System.Collections.Generic;
using FrameworklessServerKata.RequestControllers;
using Xunit;

namespace FrameworklessServerKata.Tests
{
    public class RoutingTableTests
    {
        private readonly RoutingTable _routingTable;
        private readonly PeopleModel _peopleModel;

        public RoutingTableTests()
        {
            _routingTable = new RoutingTable();
            _peopleModel = new PeopleModel();
            _peopleModel.Add("Michael");
            _peopleModel.Add("Will");
        }
        
        [Theory]
        [InlineData("http://localhost:8080/", typeof(GreetRequestController))]
        [InlineData("http://localhost:8080/people", typeof(PeopleRequestController))]
        [InlineData("http://localhost:8080/people/david", typeof(PersonRequestController))]
        public void ShouldReturnCorrectRequestController_WhenGivenValidUrl(string url, Type expectedType)
        {
            var result = _routingTable.GetRequestController(url, _peopleModel);

            Assert.IsType(expectedType, result);
        }

        [Theory]
        [InlineData("http://localhost:3000/")]
        [InlineData("http://localhost:8080/people/fake_person")]

        public void ShouldThrowArgumentException_WhenGivenInvalidUrl(string url)
        {
            Assert.Throws<ArgumentException>(() => _routingTable.GetRequestController(url, _peopleModel));
        }
    }
}