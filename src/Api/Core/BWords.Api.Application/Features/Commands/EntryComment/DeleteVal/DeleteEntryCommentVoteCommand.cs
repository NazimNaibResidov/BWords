using MediatR;

namespace BWords.Api.Application.Features.Commands.EntryComment.DeleteVal
{
    public class DeleteEntryCommentVoteCommand:IRequest<bool>
    {
        public Guid EntryCommentId { get; set; }
        public Guid UserId { get; set; }
    }
}
