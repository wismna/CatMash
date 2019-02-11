using System.Collections.Generic;

namespace CatMash.App.Interfaces
{
    public interface IImageService
    {
        IEnumerable<IImage> Images { get; }
    }
}
