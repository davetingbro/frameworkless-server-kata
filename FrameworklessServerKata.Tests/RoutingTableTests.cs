using FrameworklessServerKata.RequestControllers;
using Xunit;

namespace FrameworklessServerKata.Tests
{
    public class RoutingTableTests
    {
        [Fact]
        public void ShouldReturnGreetRequestController_WhenGivenRootUrl()
        {
            var routingTable = new RoutingTable();

            var result = routingTable.GetRequestController("http://localhost:8080/");

            Assert.IsType<GreetRequestController>(result);
        }
    }
}