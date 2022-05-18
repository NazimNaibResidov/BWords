using BWords.Api.Application.Interfaces.Repostoryes;
using BWords.Api.Domain.Models;
using BWords.infrastructure.Persistent.Context;

namespace BWords.infrastructure.Persistent.Repostors
{
    public class UserRepstory : GenericRepstory<User>,IUserRepstory
    {
        public UserRepstory(BWordsContext Dbcontext) : base(Dbcontext)
        {
        }
    }
}
