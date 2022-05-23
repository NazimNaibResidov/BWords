using BWords.Common;
using BWords.Common.Events.EntryVal;
using BWords.Common.Infrastructure;
using BWords.Common.Models.RequestModel;
using MediatR;

namespace BWords.Api.Application.Features.Commands.Entry.CrateVote
{
    public class DeleteEntryVoteCommandHandler : IRequestHandler<DeleteEntryVoteCommand, bool>
    {
        public async Task<bool> Handle(DeleteEntryVoteCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(WordConstants.FavEntryExcancedName, WordConstants.defaultExcanceType, WordConstants.EntryValQueueName, new DeleteEntryVoteEvent()
            {
                CreateById = request.UserId,
                EntryId = request.EntryId,
                
            });
            return await Task.FromResult(true);
        }
    }
}
