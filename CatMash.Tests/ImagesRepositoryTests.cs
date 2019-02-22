using System;
using CatMash.Infrastructure;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace CatMash.Tests
{
    public class ImagesRepositoryTests
    {
        [Fact]
        public void TestGetImagesWithNoUrlFails()
        {
            Assert.Throws<AggregateException>(() => new ImageRepository(Mock.Of<IConfiguration>()));
        }

        [Fact]
        public void TestGetImagesWithValidUrlSucceeds()
        {
            var imageRepository = new ImageRepository(Mock.Of<IConfiguration>(c => c["ApiUrl"] == "https://latelier.co/data/cats.json"));
            var images = imageRepository.Images;
            Assert.NotEmpty(images);
        }
    }
}