using BWords.Common;
using BWords.Common.Events.EntryFav;
using BWords.Common.Infrastructure;
using BWords.Common.Models.RequestModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Api.Application.Features.Commands.Entry.CreateFav
{
    internal class DeleteEntryFavCommandHandler : IRequestHandler<DeleteEntryFavCommand, bool>
    {
        public async Task<bool> Handle(DeleteEntryFavCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(WordConstants.FavEntryExcancedName, WordConstants.defaultExcanceType,
                WordConstants.DeleteEntryFavQueueName, new EntryDeleteFavEvent
                ()
                {
                    EntryId = request.EntryId,
                    CreateBy = request.UserId
                });
            return await Task.FromResult(true);
        }
    }
}
