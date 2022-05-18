namespace BWords.Api.Domain.Models
{
    public class EntryFovorite : BaseEntity
    {
        public Guid CreateById { get; set; }
        public Guid EntryId { get; set; }
        public virtual Entiry Entiry { get; set; }
        public virtual User GreatedUser { get; set; }

    }
}
