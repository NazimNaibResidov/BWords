using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Api.Application.Features.Commands.EntryComment.DeleteFav
{
    public class DeleteEntryCommentFavCommand:IRequest<bool>
    {
        public Guid UserId { get; set; }
        public Guid CommentId { get; set; }
    }
}
