using BWords.Common;
using BWords.Common.Events.EntryComment;
using BWords.Common.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Api.Application.Features.Commands.EntryComment.DeleteVal
{
    public class DeleteEntryCommentVoteCommandHandler : IRequestHandler<DeleteEntryCommentVoteCommand, bool>
    {
        public async Task<bool> Handle(DeleteEntryCommentVoteCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(WordConstants.FavEntryExcancedName, WordConstants.defaultExcanceType, WordConstants.ValEntryCommentQueueName,
          new DeleteEntryCommentVoteCommandEvent() { EntryCommentId = request.EntryCommentId, UserId = request.UserId });
            return await Task.FromResult(true);
        }
    }
}
