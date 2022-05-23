namespace BWords.Api.Domain.Models
{
    public class EntryComment : BaseEntity
    {
        public string Content { get; set; }
        public Guid CreateById { get; set; }
        public Guid EntiryId { get; set; }
        public virtual Entiry Entiry { get; set; }
        public virtual User CreateBy { get; set; }
        public virtual ICollection<EntryCommentVote> EntityCommentVotes { get; set; }
        public virtual ICollection<EntryCommentFovorite> EntityCommentFovorites { get; set; }
    }
}
