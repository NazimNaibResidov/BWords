using AutoMapper;
using BWords.Api.Application.Interfaces.Repostoryes;
using BWords.Common.Models.RequestModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Api.Application.Features.Commands.Entry.Create
{
    public class CreateEntryCommandHandler : IRequestHandler<CreateEntryCommand, Guid>
    {
        private readonly IEntryRepstory _repstory;
        private readonly IMapper _mapper;

        public CreateEntryCommandHandler(IEntryRepstory repstory, IMapper mapper)
        {
            _repstory = repstory;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateEntryCommand request, CancellationToken cancellationToken)
        {
            var dbEntry= _mapper.Map<Domain.Models.Entiry>(request);
           await _repstory.AddAsync(dbEntry);
            return dbEntry.Id;
        }
    }
}
