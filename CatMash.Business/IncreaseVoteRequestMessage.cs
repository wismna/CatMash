using CatMash.Business.Interfaces;
using CatMash.Entities;

namespace CatMash.Business
{
    public class IncreaseVoteRequestMessage: IRequest<IncreaseVoteResponseMessage>
    {
        public string Id { get; set; }
    }
}