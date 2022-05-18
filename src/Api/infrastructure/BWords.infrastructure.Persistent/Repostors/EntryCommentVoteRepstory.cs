using BWords.Api.Application.Interfaces.Repostoryes;
using BWords.Api.Domain.Models;
using BWords.infrastructure.Persistent.Context;

namespace BWords.infrastructure.Persistent.Repostors
{
    public class EntryCommentVoteRepstory : GenericRepstory<EntryCommentVote>, IEntryCommentVoteRepstory
    {
        public EntryCommentVoteRepstory(BWordsContext Dbcontext) : base(Dbcontext)
        {
        }
    }
}
