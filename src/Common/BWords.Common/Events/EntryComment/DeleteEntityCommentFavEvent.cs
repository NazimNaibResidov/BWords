namespace BWords.Common.Events.EntryComment
{
    public class DeleteEntityCommentFavEvent
    {
        public Guid EntityCommentId { get; set; }
        public Guid Create { get; set; }
    }
}
