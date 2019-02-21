using System.Runtime.Serialization;

namespace CatMash.Entities
{
    [DataContract]
    public class Image
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        public int Votes { get; set; }

        public void IncreaseVotes()
        {
            Votes ++;
        }
    }
}