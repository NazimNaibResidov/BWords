using BWords.Common.Models.Pages;
using BWords.Common.Models.Quiers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Api.Application.Features.Queris.GetMainPageEntries
{
    public class GetMainPageEntrieQuery:BasePageQuery,IRequest<PagedViewModel<GetEntryDeatilViewModel>>
    {
        public GetMainPageEntrieQuery(Guid? UserId,int page,int PageSize):base(page,PageSize)
        {
            this.UserId = UserId;
        }
        public Guid? UserId { get; set; }
    }
}
