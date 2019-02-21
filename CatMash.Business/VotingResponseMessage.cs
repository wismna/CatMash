using System.Collections.Generic;
using CatMash.Business.Interfaces;
using CatMash.Entities;

namespace CatMash.Business
{
    public class VotingResponseMessage: IRequest
    {
        public IEnumerable<Image> Images;
    }
}