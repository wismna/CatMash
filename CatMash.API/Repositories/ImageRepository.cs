using System.Collections.Generic;
using System.Runtime.Serialization;
using CatMash.API.Model;

namespace CatMash.API.Repositories
{
    [DataContract]
    public class ImageRepository
    {
        [DataMember(Name = "images")]
        public List<Image> Images { get; set; }
    }
}
