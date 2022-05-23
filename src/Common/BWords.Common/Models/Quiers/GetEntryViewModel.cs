namespace BWords.Common.Models.Quiers
{
    public class GetEntryViewModel
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public int CommentCount { get; set; }
    }
}
