using CatMash.API.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatMash.App.Interfaces
{
    public interface IImageService
    {
        IEnumerable<IImage> Images { get; }
    }
}
