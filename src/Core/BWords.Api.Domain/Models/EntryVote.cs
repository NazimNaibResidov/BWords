using BWords.Common.ViewModels;

namespace BWords.Api.Domain.Models
{
    public class EntryVote : BaseEntity
    {
        public Guid EntiryId { get; set; }
        public VoteType VoteType { get; set; }
        public Guid CreateById { get; set; }
        public virtual Entiry Entiry { get; set; }
        public virtual EmailConfiguration EntryComment { get; set; }
    }
}
