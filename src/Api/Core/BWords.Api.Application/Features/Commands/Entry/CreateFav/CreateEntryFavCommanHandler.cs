using BWords.Common;
using BWords.Common.Events.EntryFav;
using BWords.Common.Infrastructure;
using MediatR;

namespace BWords.Api.Application.Features.Commands.Entry.CreateFav
{
    public class CreateEntryFavCommanHandler : IRequestHandler<CreateEntryFavComman, bool>
    {
        public async Task<bool> Handle(CreateEntryFavComman request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(WordConstants.EntryValExcancedName, WordConstants.defaultExcanceType, WordConstants.EntryValQueueName,
                new EntryFavEvent()
                {
                    EntryId = request.EntryId,
                    UserId = request.UserId
                });
            return await Task.FromResult(true);
        }
    }
}
