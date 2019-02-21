using System;
using CatMash.App.Repositories;
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
            var imageRepository = new ImageRepository(Mock.Of<IConfiguration>());
            Assert.Throws<AggregateException>(() => imageRepository.Images);
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