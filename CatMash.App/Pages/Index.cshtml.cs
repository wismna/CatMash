using CatMash.App.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatMash.App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IVotingService _votingService;

        public IndexModel(IVotingService votingService)
        {
            _votingService = votingService;
        }

        public void OnPostVote(string id)
        {
            _votingService.Vote(id);
        }
    }
}
