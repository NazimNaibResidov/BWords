namespace BWords.Api.Domain.Models
{
    public class User : BaseEntity
    {

        public string FristName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool EmailConfirmed { get; set; }
        public virtual ICollection<Entiry> Entiries { get; set; }
        public virtual ICollection<EntryFovorite> EntityFovorites { get; set; }
        public virtual ICollection<EntryComment> EntryComments { get; set; }
        public virtual ICollection<EmailConfiguration> EntityComments { get; set; }
        public virtual ICollection<EntryCommentFovorite> EntityCommentFovorites { get; set; }

    }
    public class EntryCommentFovorite : BaseEntity
    {
        public Guid EntryCommandId { get; set; }
        public Guid CreateById { get; set; }
        public EntryComment EntryComment { get; set; }
        public User CreatedUser { get; set; }
    }
}
