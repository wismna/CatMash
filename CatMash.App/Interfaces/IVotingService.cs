using System.Collections.Generic;

namespace CatMash.App.Interfaces
{
    public interface IVotingService
    {
        IEnumerable<IImage> GetImagesToCompare();

        void Vote(string imageId);
    }
}
