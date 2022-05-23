namespace BWords.Api.Domain.Models
{
    public class EmailConfiguration : BaseEntity
    {
        public string OldEmailAdress { get; set; }
        public string NewEmailAdress { get; set; }
    }
}
