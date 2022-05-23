using BWords.Api.Application.Interfaces.Repostoryes;
using BWords.Api.Domain.Models;
using BWords.infrastructure.Persistent.Context;

namespace BWords.infrastructure.Persistent.Repostors
{
    public class EntryRepstory : GenericRepstory<Entiry>, IEntryRepstory
    {
        public EntryRepstory(BWordsContext Dbcontext) : base(Dbcontext)
        {
        }
    }
}
