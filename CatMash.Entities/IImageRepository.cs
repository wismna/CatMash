using System.Collections.Generic;

namespace CatMash.Entities
{
    public interface IImageRepository
    {
        IEnumerable<Image> Images { get; }
    }
}