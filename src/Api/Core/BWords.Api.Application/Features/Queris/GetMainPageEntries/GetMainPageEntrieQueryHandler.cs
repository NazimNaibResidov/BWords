using AutoMapper;
using BWords.Api.Application.Interfaces.Repostoryes;
using BWords.Common.Infrastructure.Extensions;
using BWords.Common.Models.Pages;
using BWords.Common.Models.Quiers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BWords.Api.Application.Features.Queris.GetMainPageEntries
{
    public class GetMainPageEntrieQueryHandler : IRequestHandler<GetMainPageEntrieQuery, PagedViewModel<GetEntryDeatilViewModel>>
    {
        private readonly IEntryRepstory repstory;
       

        public GetMainPageEntrieQueryHandler(IEntryRepstory repstory)
        {
            this.repstory = repstory;
            
        }
        public async Task<PagedViewModel<GetEntryDeatilViewModel>> Handle(GetMainPageEntrieQuery request, CancellationToken cancellationToken)
        {
            var query = repstory.AsQueryable();
            query = query.
                  Include(x => x.EntityFovorites)
                  .Include(x => x.CreateBy)
                  .Include(x => x.EntityVotes);
            var list = query.Select(x => new GetEntryDeatilViewModel()
            {
                Id = x.Id,
                Subject = x.Subject,
                Content = x.Content,
                IsFavorite = request.UserId.HasValue && x.EntityFovorites.Any(j => j.CreateById == request.UserId),
                FavoriteCount = x.EntityFovorites.Count,
                CreateDate = x.CreateDate,
                CreatedByName = x.CreateBy.UserName,
                VoteTypes = request.UserId.HasValue && x.EntityVotes.Any(j => j.CreateById == request.UserId)
                ? x.EntityVotes.FirstOrDefault(z => z.CreateById == request.UserId).VoteType
                : Common.ViewModels.VoteTypes.None

            });
            var entites = await list.GetPages(request.Page, request.PageSize);
            return new PagedViewModel<GetEntryDeatilViewModel>(entites.Results, entites.PageInfo);
        }
    }
}
