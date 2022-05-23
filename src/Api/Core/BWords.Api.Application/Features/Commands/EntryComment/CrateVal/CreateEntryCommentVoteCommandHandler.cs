using BWords.Common;
using BWords.Common.Events.EntryComment;
using BWords.Common.Infrastructure;
using BWords.Common.Models.RequestModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Api.Application.Features.Commands.EntryComment.CrateVal
{
    public class CreateEntryCommentVoteCommandHandler : IRequestHandler<CreateEntryCommentVoteCommand,bool>
    {
        
        public async Task<bool> Handle(CreateEntryCommentVoteCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(WordConstants.FavEntryExcancedName, WordConstants.defaultExcanceType, WordConstants.CreateEntryCommentVoteQueueName, new CreateEntityCommentVoteEvent()
            {
               CreateBy=request.CreateBy,
               ValueTypes=request.VoteTypes,
               EntryCommentId=request.EntryCommentId

            });
            return await Task.FromResult(true);
        }
    }
}
