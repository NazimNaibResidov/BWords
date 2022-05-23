using BWords.Common;
using BWords.Common.Events.EntryVal;
using BWords.Common.Infrastructure;
using BWords.Common.Models.RequestModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Api.Application.Features.Commands.Entry.CrateVote
{
    public class CreateEntryVoteCommandHandler : IRequestHandler<CreateEntryVoteCommand,bool>
    {
        public async Task<bool> Handle(CreateEntryVoteCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(WordConstants.EntryValQueueName, WordConstants.defaultExcanceType, WordConstants.EntryValQueueName,new CreateEntryVoteEvent()
            {
                CreateById=request.CreateById,
                EntryId=request.EntryId,
                VoteTypes=request.voteTypes
            });
            return await Task.FromResult(true);

        }
    }
}
