using System.Collections.Generic;
using CatMash.Business;
using CatMash.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatMash.App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IImageRepository _imageRepository;

        public IEnumerable<Image> Images;

        public IndexModel(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;

            var interactor = new RequestVotingImagesInteractor();
            var response = interactor.Handle(new VotingRequestMessage {Images = _imageRepository.Images});
            if (response != null) Images = response.Images;
        }
        
        public void OnPostVote(string id)
        {
            var interactor = new IncreaseVoteInteractor(_imageRepository);
            interactor.Handle(new IncreaseVoteRequestMessage {Id = id});
        }
    }
}
