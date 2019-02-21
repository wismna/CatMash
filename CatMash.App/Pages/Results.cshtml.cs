using System.Collections.Generic;
using System.Linq;
using CatMash.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatMash.App.Pages
{
    public class ResultsModel : PageModel
    {
        private readonly IImageRepository _imageRepository;

        [BindProperty]
        public IEnumerable<Image> Images { get; private set; }

        [BindProperty]
        public int MaxVotes { get; private set; }

        public ResultsModel(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        public void OnGet()
        {
            Images = _imageRepository.Images.OrderByDescending(i => i.Votes);
            MaxVotes = Images.First().Votes;
        }
    }
}