using System.Collections.Generic;
using System.Linq;
using CatMash.App.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatMash.App.Pages
{
    public class ResultsModel : PageModel
    {
        private readonly IImageService _imageService;

        [BindProperty]
        public IEnumerable<IImage> Images { get; private set; }

        public ResultsModel(IImageService imageService)
        {
            _imageService = imageService;
        }
        public void OnGet()
        {
            Images = _imageService.Images.OrderByDescending(i => i.Votes);
        }
    }
}