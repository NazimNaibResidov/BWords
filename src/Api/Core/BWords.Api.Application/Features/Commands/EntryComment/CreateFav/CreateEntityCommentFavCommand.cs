using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Api.Application.Features.Commands.EntryComment.CreateFav
{
    public class CreateEntityCommentFavCommand : IRequest<bool>
    {
        public CreateEntityCommentFavCommand(Guid commentId)
        {
            CommentId = commentId;
        }

        public Guid UserId { get; set; }
        public Guid CommentId { get; set;
        }
    }
}
