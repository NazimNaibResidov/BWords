namespace BWords.Common.Events.EntryFav
{
    public class EntryDeleteFavEvent
    {
       

        public Guid? EntryId { get; set; }
        public Guid? CreateBy { get; set; }
    }
}
