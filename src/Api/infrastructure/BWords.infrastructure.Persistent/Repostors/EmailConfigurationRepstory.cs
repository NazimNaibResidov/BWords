using BWords.Api.Application.Interfaces.Repostoryes;
using BWords.Api.Domain.Models;
using BWords.infrastructure.Persistent.Context;

namespace BWords.infrastructure.Persistent.Repostors
{
    public class EmailConfigurationRepstory : GenericRepstory<EmailConfiguration>, IEmailConfigurationRepstory
    {
        public EmailConfigurationRepstory(BWordsContext Dbcontext) : base(Dbcontext)
        {
        }
    }
}
