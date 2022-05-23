using BWords.Common;
using BWords.Common.Events.EntryComment;
using BWords.Common.Infrastructure;
using MediatR;

namespace BWords.Api.Application.Features.Commands.EntryComment.CreateFav
{
    public class CreateEntityCommentFavCommandHandler : IRequestHandler<CreateEntityCommentFavCommand, bool>
    {
        public Task<bool> Handle(CreateEntityCommentFavCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(WordConstants.EntryCommentExcancedName, WordConstants.defaultExcanceType, WordConstants.UserEmailChancedQueueName,
new CreateEntityCommentFavEvent() { CommentId = request.CommentId, UserId = request.UserId });
            return Task.FromResult(true);
        }
    }
}
