namespace BWords.Common.Events.EntryComment
{
    public class DeleteEntryCommentVoteCommandEvent
    {
        public Guid EntryCommentId { get; set; }
        public Guid UserId { get; set; }
    }
}
