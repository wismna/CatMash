using Xunit;
using CatMash.API.Controllers;

namespace CatMash.Tests
{
    public class ApiTests
    {
        [Fact]
        public void TestGetVotingObjects()
        {
            var apiController = new ImagesController();
            var votingObjects = apiController.GetVotingObjects();
            Assert.NotNull(votingObjects);
        }
    }
}