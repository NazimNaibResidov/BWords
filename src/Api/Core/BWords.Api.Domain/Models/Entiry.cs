namespace BWords.Api.Domain.Models
{
   
    public class Entiry : BaseEntity
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public Guid CreateById { get; set; }
        public virtual User CreateBy { get; set; }
        public virtual ICollection<EntryComment> EntryComments { get; set; }
        public virtual ICollection<EntryVote> EntityVotes { get; set; }
        public virtual ICollection<EntryFovorite> EntityFovorites { get; set; }
    }
}
