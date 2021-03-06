using BWords.Api.Application.Interfaces.Repostoryes;
using BWords.Api.Domain.Models;
using BWords.infrastructure.Persistent.Context;

namespace BWords.infrastructure.Persistent.Repostors
{
    public class EntryVoteRepstory : GenericRepstory<EntryVote>, IEntryVoteRepstory
    {
        public EntryVoteRepstory(BWordsContext Dbcontext) : base(Dbcontext)
        {
        }
    }
}
