using BWords.Api.Application.Interfaces.Repostoryes;
using BWords.Api.Domain.Models;
using BWords.infrastructure.Persistent.Context;

namespace BWords.infrastructure.Persistent.Repostors
{
    public class EntryFovoriteRepstory : GenericRepstory<EntryFovorite>, IEntryFovoriteRepstory
    {
        public EntryFovoriteRepstory(BWordsContext Dbcontext) : base(Dbcontext)
        {
        }
    }
}
