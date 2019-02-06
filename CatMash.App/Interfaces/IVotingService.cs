using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatMash.API.Interfaces;

namespace CatMash.App.Interfaces
{
    public interface IVotingService
    {
        IEnumerable<IImage> GetImagesToCompare();

        void Vote(IImage image);
    }
}
