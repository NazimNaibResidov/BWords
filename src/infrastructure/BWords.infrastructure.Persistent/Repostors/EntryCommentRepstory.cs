using BWords.Api.Application.Interfaces.Repostoryes;
using BWords.Api.Domain.Models;
using BWords.infrastructure.Persistent.Context;

namespace BWords.infrastructure.Persistent.Repostors
{
    public class EntryCommentRepstory : GenericRepstory<EntryComment>, IEntryCommentRepstory
    {
        public EntryCommentRepstory(BWordsContext Dbcontext) : base(Dbcontext)
        {
        }
    }
}
