using MediatR;

namespace BWords.Common.Models.RequestModel
{
    public class CreateEntryCommentCommand : IRequest<Guid>
    {
       

        public Guid EntryId { get; set; }
        public string Content { get; set; }
        public Guid? CreateById { get; set; }
    }
}
