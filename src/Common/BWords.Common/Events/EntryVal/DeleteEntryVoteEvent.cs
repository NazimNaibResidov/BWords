using BWords.Common.Models.RequestModel;
using BWords.Common.ViewModels;

namespace BWords.Common.Events.EntryVal
{
    public class DeleteEntryVoteEvent : BaseCommand
    {
        public VoteTypes VoteTypes { get; set; }
    }

}
