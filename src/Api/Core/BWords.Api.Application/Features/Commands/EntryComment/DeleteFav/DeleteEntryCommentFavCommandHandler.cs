using BWords.Common;
using BWords.Common.Events.EntryComment;
using BWords.Common.Infrastructure;
using MediatR;

namespace BWords.Api.Application.Features.Commands.EntryComment.DeleteFav
{
    public class DeleteEntryCommentFavCommandHandler : IRequestHandler<DeleteEntryCommentFavCommand, bool>
    {
        public async Task<bool> Handle(DeleteEntryCommentFavCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(WordConstants.FavEntryExcancedName, WordConstants.defaultExcanceType, WordConstants.FavEntryCommentQueueName,
           new DeleteEntityCommentFavEvent() {EntityCommentId=request.CommentId,Create=request.UserId});
            return await Task.FromResult(true);
        }
    }
}
