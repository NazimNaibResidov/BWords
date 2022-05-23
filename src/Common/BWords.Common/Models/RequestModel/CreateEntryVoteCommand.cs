using BWords.Common.ViewModels;
using MediatR;

namespace BWords.Common.Models.RequestModel
{
    public class CreateEntryVoteCommand:BaseCommand , IRequest<bool>
    {
        public VoteTypes voteTypes { get; set; }
    }
}
