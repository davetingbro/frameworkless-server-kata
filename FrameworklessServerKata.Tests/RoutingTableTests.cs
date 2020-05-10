using System;
using FrameworklessServerKata.RequestControllers;
using Xunit;

namespace FrameworklessServerKata.Tests
{
    public class RoutingTableTests
    {
        [Theory]
        [InlineData("http://localhost:8080/", typeof(GreetRequestController))]
        [InlineData("http://localhost:8080/people", typeof(PeopleRequestController))]

        public void ShouldReturnCorrectRequestController_WhenGivenValidUrl(string url, Type expectedType)
        {
            var routingTable = new RoutingTable();

            var result = routingTable.GetRequestController(url);

            Assert.IsType(expectedType, result);
        }
    }
}