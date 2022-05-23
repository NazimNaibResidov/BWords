using MediatR;

namespace BWords.Common.Models.RequestModel
{
    public class DeleteEntryVoteCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public Guid EntryId { get; set; }
    }
}
