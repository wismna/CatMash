using System;
using Xunit;
using CatMash.API.Controllers;
using Microsoft.Extensions.Configuration;
using Moq;

namespace CatMash.Tests
{
    public class ApiTests
    {
        [Fact]
        public void TestGetImagesWithNoUrlFails()
        {
            var apiController = new ImagesController(Mock.Of<IConfiguration>());
            Assert.ThrowsAsync<UriFormatException>(async () => await apiController.GetImages());
        }

        [Fact]
        public void TestGetImagesWithValidUrlSucceeds()
        {
            var apiController = new ImagesController(Mock.Of<IConfiguration>(c => c["SourceImagesUrl"] == "https://latelier.co/data/cats.json"));
            var images = apiController.GetImages().Result;
            Assert.NotEmpty(images);
        }
    }
}