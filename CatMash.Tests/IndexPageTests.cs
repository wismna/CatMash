using System.Collections.Generic;
using CatMash.App.Pages;
using CatMash.Entities;
using Moq;
using Xunit;

namespace CatMash.Tests
{
    public class IndexPageTests
    {
        [Fact]
        public void TestVoteShouldIncreaseVoteCount()
        {
            var images = new List<Image> { new Image { Id = "id1" } };
            var indexPage = new IndexModel(Mock.Of<IImageRepository>(i => i.Images == images));
            indexPage.OnPostVote(images[0].Id);
            Assert.Equal(1, images[0].Votes);
        }
    }
}