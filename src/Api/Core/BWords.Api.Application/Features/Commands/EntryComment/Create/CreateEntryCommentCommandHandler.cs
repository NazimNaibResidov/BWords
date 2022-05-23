using AutoMapper;
using BWords.Api.Application.Interfaces.Repostoryes;
using BWords.Common.Models.RequestModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Api.Application.Features.Commands.EntryComment.Create
{
    public class CreateEntryCommentCommandHandler : IRequestHandler<CreateEntryCommentCommand, Guid>
    {
        private readonly IEntryCommentRepstory repstory;
        private readonly IMapper mapper;

        public CreateEntryCommentCommandHandler(IEntryCommentRepstory repstory, IMapper mapper)
        {
            this.repstory = repstory;
            this.mapper = mapper;
        }

        public async Task<Guid> Handle(CreateEntryCommentCommand request, CancellationToken cancellationToken)
        {
            var dbEntryComment= mapper.Map<BWords.Api.Domain.Models.EntryComment>(request);
            await repstory.AddAsync(dbEntryComment);
            return await Task.FromResult(dbEntryComment.Id);
        }
    }
}
