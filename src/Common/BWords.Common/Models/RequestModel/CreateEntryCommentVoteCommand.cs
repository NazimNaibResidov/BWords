using BWords.Common.ViewModels;
using MediatR;

namespace BWords.Common.Models.RequestModel
{
    public class CreateEntryCommentVoteCommand : IRequest<bool>
    {
        public Guid EntryCommentId { get; set; }
        public VoteTypes VoteTypes { get; set; }
        public Guid CreateBy { get; set; }
    }
}
