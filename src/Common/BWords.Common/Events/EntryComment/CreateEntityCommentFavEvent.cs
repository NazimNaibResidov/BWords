using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Common.Events.EntryComment
{
    public class CreateEntityCommentFavEvent
    {
        public Guid UserId { get; set; }
        public Guid CommentId { get; set; }
    }
    public class CreateEntityCommentVoteEvent
    {
        public Guid CreateBy { get; set; }
        public ValueType ValueTypes  { get; set; }
        public Guid EntryCommentId { get; set; }
    }
}
