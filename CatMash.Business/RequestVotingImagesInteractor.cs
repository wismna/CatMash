using System;
using System.Linq;
using CatMash.Business.Interfaces;

namespace CatMash.Business
{
    public class RequestVotingImagesInteractor : IRequestHandler<VotingRequestMessage, VotingResponseMessage>
    {
        public VotingResponseMessage Handle(VotingRequestMessage message)
        {
            if (message.Images == null || message.Images.Count() < 2) return new VotingResponseMessage();

            var count = message.Images.Count();
            var array = message.Images.ToArray();
            var random = new Random();
            for (var i = count - 1; i >= count - 2; i--)
            {
                var j = random.Next(i);
                var tmp = array[i];
                array[i] = array[j];
                array[j] = tmp;
            }

            return new VotingResponseMessage {Images = array.Skip(count - 2).Take(2)};
        }
    }
}