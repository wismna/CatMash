using System.Collections.Generic;
using System.Linq;
using CatMash.App.Interfaces;
using CatMash.App.Models;
using CatMash.App.Services;
using Moq;
using Xunit;

namespace CatMash.Tests
{
    public class AppTests
    {
        private readonly List<IImage> _images = new List<IImage>() {new Image {Id = "id1"}, new Image {Id = "id2"}, new Image { Id = "id3" }, new Image { Id = "id4" } };
        private readonly IImageService _imageService;

        public AppTests()
        {
            _imageService = Mock.Of<IImageService>(i => i.Images == _images);
        }

        [Fact]
        public void TestVotingServiceGetImagesShouldBeDifferent()
        {
            var votingService = new VotingService(_imageService);
            var images = votingService.GetImagesToCompare().ToList();
            Assert.Equal(2, images.Count());
            Assert.NotEqual(images[0].Id, images[1].Id);
        }

        [Fact]
        public void TestVotingServiceIncreaseVoteCount()
        {
            var votingService = new VotingService(_imageService);
            votingService.Vote(_images[0].Id);
            Assert.Equal(1, _images[0].Votes);
        }
    }
}
