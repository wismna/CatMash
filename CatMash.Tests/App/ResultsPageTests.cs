using System.Collections.Generic;
using CatMash.App.Interfaces;
using CatMash.App.Models;
using CatMash.App.Pages;
using Moq;
using Xunit;

namespace CatMash.Tests.App
{
    public class ResultsPageTests
    {
        private const int MaxVotes = 3;

        [Fact]
        public void GetVoteShouldStayOnSamePage()
        {
            var images = new List<IImage> {new Image {Id = "id1"}, new Image {Id = "id2", Votes = MaxVotes}};
            var resultsPage = new ResultsModel(Mock.Of<IImageService>(i => i.Images == images));
            resultsPage.OnGet();
            Assert.Equal(MaxVotes,resultsPage.MaxVotes);
        }
    }
}