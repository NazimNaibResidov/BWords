using MediatR;

namespace BWords.Common.Models.RequestModel
{
    
    public class DeleteEntryFavCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public Guid EntryId { get; set; }
    }
}
