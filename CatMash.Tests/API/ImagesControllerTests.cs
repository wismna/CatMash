using System;
using System.Threading.Tasks;
using CatMash.API.Controllers;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace CatMash.Tests.API
{
    public class ImagesControllerTests
    {
        [Fact]
        public async Task TestGetImagesWithNoUrlFails()
        {
            var apiController = new ImagesController(Mock.Of<IConfiguration>());
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await apiController.GetImages());
        }

        [Fact]
        public async Task TestGetImagesWithValidUrlSucceeds()
        {
            var apiController = new ImagesController(Mock.Of<IConfiguration>(c => c["SourceImagesUrl"] == "https://latelier.co/data/cats.json"));
            var images = await apiController.GetImages();
            Assert.NotEmpty(images);
        }
    }
}