using BWords.Common.Models.Pages;

namespace BWords.Common.Models.Quiers
{
    public class GetEntryDeatilViewModel: BaseRateFavoriteViewModel
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedByName { get; set; }
    }
}
