using System.Collections.Generic;
using CatMash.Business.Interfaces;
using CatMash.Entities;

namespace CatMash.Business
{
    public class VotingRequestMessage: IRequest<VotingResponseMessage>
    {
        public IEnumerable<Image> Images;
    }
}