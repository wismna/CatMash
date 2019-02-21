using System.Collections.Generic;
using CatMash.App.Pages;
using CatMash.Entities;
using Moq;
using Xunit;

namespace CatMash.Tests
{
    public class ResultsPageTests
    {
        private const int MaxVotes = 3;

        [Fact]
        public void TestMaxVotesImageShouldBeOnTopOfResultsPage()
        {
            var images = new List<Image> {new Image {Id = "id1"}, new Image {Id = "id2", Votes = MaxVotes}};
            var resultsPage = new ResultsModel(Mock.Of<IImageRepository>(i => i.Images == images));
            resultsPage.OnGet();
            Assert.Equal(MaxVotes,resultsPage.MaxVotes);
        }
    }
}