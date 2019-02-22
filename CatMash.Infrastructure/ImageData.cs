using System.Collections.Generic;
using System.Runtime.Serialization;
using CatMash.Entities;

namespace CatMash.Infrastructure
{
    [DataContract]
    public class ImageData
    {
        [DataMember(Name = "images")]
        public IEnumerable<Image> Images { get; set; }
    }
}