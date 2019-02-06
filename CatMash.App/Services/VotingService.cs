using System;
using System.Collections.Generic;
using System.Linq;
using CatMash.App.Interfaces;

namespace CatMash.App.Services
{
    public class VotingService: IVotingService
    {
        private readonly IImageService _imageService;
        public VotingService(IImageService imageService)
        {
            _imageService = imageService;
        }

        // Implement Fisher-Yates algorithm
        public IEnumerable<IImage> GetImagesToCompare()
        {
            var count = _imageService.Images.Count();
            var array = _imageService.Images.ToArray();
            var random = new Random();
            for (var i = count - 1; i >= count - 2; i--)
            {
                var j = random.Next(i);
                var tmp = array[i];
                array[i] = array[j];
                array[j] = tmp;
            }

            return array.Skip(count - 2).Take(2);
        }

        public void Vote(IImage image)
        {
            image.Votes++;
        }
    }
}
