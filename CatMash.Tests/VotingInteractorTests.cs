using System.Collections.Generic;
using System.Linq;
using CatMash.Business;
using CatMash.Entities;
using Moq;
using Xunit;

namespace CatMash.Tests
{
    public class InteractorTests
    {
        private readonly List<Image> _images = new List<Image> {new Image {Id = "id1"}, new Image {Id = "id2"}, new Image { Id = "id3" }, new Image { Id = "id4" } };
        private readonly IImageRepository _imageRepository;

        public InteractorTests()
        {
            _imageRepository = Mock.Of<IImageRepository>(i => i.Images == _images);
        }

        [Fact]
        public void TestVotingServiceGetImagesShouldBeDifferent()
        {
            var votingImagesInteractor = new RequestVotingImagesInteractor();
            var response = votingImagesInteractor.Handle(new VotingRequestMessage {Images = _images});
            var images = response.Images.ToList();
            Assert.Equal(2, images.Count());
            Assert.NotEqual(images[0].Id, images[1].Id);
        }

        [Fact]
        public void TestVotingServiceIncreaseVoteCount()
        {
            var increaseVoteInteractor = new IncreaseVoteInteractor(_imageRepository);
            increaseVoteInteractor.Handle(new IncreaseVoteRequestMessage {Id = _images[0].Id});
            Assert.Equal(1, _images[0].Votes);
        }
    }
}
