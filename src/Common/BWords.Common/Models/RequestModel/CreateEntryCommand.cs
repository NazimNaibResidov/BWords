using MediatR;

namespace BWords.Common.Models.RequestModel
{
    public class CreateEntryCommand:IRequest<Guid>
    {
        public CreateEntryCommand(string content, Guid createById)
        {
            Content = content;
            CreateById = createById;
        }

        public string Subject { get; set; }
        public string Content { get; set; }
        public Guid? CreateById { get; set; }
    }
}
