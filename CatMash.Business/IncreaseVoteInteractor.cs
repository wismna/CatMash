using System.Linq;
using CatMash.Business.Interfaces;
using CatMash.Entities;

namespace CatMash.Business
{
    public class IncreaseVoteInteractor : IRequestHandler<IncreaseVoteRequestMessage, IncreaseVoteResponseMessage>
    {
        private readonly IImageRepository _imageRepository;

        public IncreaseVoteInteractor(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public IncreaseVoteResponseMessage Handle(IncreaseVoteRequestMessage message)
        {
            var image = _imageRepository.Images.FirstOrDefault(i => i.Id == message.Id);
            image?.IncreaseVotes();
            return new IncreaseVoteResponseMessage();
        }
    }
}