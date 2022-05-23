using AutoMapper;
using BWords.Api.Application.Interfaces.Repostoryes;
using BWords.Common.Models.Quiers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Api.Application.Features.Queris.GetEntry
{
    public class GetEntryQuertes : IRequest<List<GetEntryViewModel>>
    {
        public bool TodayEntites { get; set; }

        public int Count { get; set; } = 100;
    }
    //public class GetEntryQuertesHandler : IRequestHandler<GetEntryQuertes, List<GetEntryViewModel>>
    //{
    //    private readonly IEntryRepstory repstory;
    //    private readonly IMapper mapper;

    //    public GetEntryQuertesHandler(IEntryRepstory repstory, IMapper mapper)
    //    {
    //        this.repstory = repstory;
    //        this.mapper = mapper;
    //    }
    //}
}
