namespace BWords.Common.Events.EntryComment
{
    public class CreateEntityCommentEvent
    {
        public Guid UserId { get; set; }
        public Guid CommentId { get; set; }
    }
}
