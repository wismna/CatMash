using System.Runtime.Serialization;
using CatMash.API.Interfaces;

namespace CatMash.API.Model
{
    [DataContract]
    public class Image: IImage
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
}
