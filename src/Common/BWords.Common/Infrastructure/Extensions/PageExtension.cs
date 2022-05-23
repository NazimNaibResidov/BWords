using BWords.Common.Models.Pages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Common.Infrastructure.Extensions
{
    public static class PageExtension
    {
        public static async Task<PagedViewModel<T>> GetPages<T>(this IQueryable<T> query,
                                                                 int currentPage,
                                                                 int pageSize) where T:class
        {
            var count  = await query.CountAsync();
            Page pagin = new(currentPage, pageSize, count);
            var data   = await query.Skip(pagin.Skip)
                .Take(pagin.PageSize)
                .AsNoTracking()
                .ToListAsync();
            var result = new PagedViewModel<T>(data, pagin);
            return result;
        }
    }
}
