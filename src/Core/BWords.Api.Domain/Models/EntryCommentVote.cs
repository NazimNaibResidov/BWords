using BWords.Common.ViewModels;

namespace BWords.Api.Domain.Models
{
    public class EntryCommentVote : BaseEntity
    {
        public Guid EntiryCommentId { get; set; }
        public VoteType VoteType { get; set; }
        public Guid CreateById { get; set; }
        public virtual Entiry Entiry { get; set; }
        public virtual EntryComment EntryComment { get; set; }
    }
}
