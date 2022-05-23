using AutoMapper;
using AutoMapper.QueryableExtensions;
using BWords.Api.Application.Interfaces.Repostoryes;
using BWords.Common.Models.Quiers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BWords.Api.Application.Features.Queris.GetEntry
{
    public class GetEntryQuertesHandler : IRequestHandler<GetEntryQuertes, List<GetEntryViewModel>>
    {
        private readonly IEntryRepstory repstory;
        private readonly IMapper mapper;

        public GetEntryQuertesHandler(IEntryRepstory repstory, IMapper mapper)
        {
            this.repstory = repstory;
            this.mapper = mapper;
        }

        public async Task<List<GetEntryViewModel>> Handle(GetEntryQuertes request, CancellationToken cancellationToken)
        {
            var query = repstory.AsQueryable();
            if (request.TodayEntites)
            {
                query = query
                    .Where(x => x.CreateDate < DateTime.Now.Date)
                    .Where(x => x.CreateDate < DateTime.Now.AddDays(1).Date);
            }
            query = query.Include(x => x.EntryComments)
                 .OrderBy(x => x.Id)
                 .Take(request.Count);
            return await query.ProjectTo<GetEntryViewModel>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
