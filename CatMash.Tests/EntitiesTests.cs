using CatMash.Entities;
using Xunit;

namespace CatMash.Tests
{
    public class EntitiesTests
    {
        [Fact]
        public void TestIncreaseVote()
        {
            var image = new Image();
            Assert.Equal(0, image.Votes);
            image.IncreaseVotes();
            Assert.Equal(1, image.Votes);
        }
    }
}