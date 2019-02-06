using System.Runtime.Serialization;
using CatMash.App.Interfaces;

namespace CatMash.App.Models
{
    [DataContract]
    public class Image : IImage
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        public int Votes { get; set; }
    }
}