using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.Application.UseCases.DTO.Searches;
using ASP_Projekat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.Extensions
{
    public static class QueryableExtensions
    {
        public static PageResponse<TDto> ToPagedResponse<TEntity, TDto>(
           this IQueryable<TEntity> query,
           PageSearch search,
           Expression<Func<TEntity, TDto>> conversion)
           where TDto : class
           where TEntity : Entity

        {
            if (search.PerPage <= 0)
            {
                search.PerPage = 10;
            }

            if (search.Page <= 0)
            {
                search.Page = 1;
            }

            var skip = (search.Page - 1) * search.PerPage;

            return new PageResponse<TDto>
            {
                TotalItems = query.Count(),
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                Items = query.Skip(skip)
                             .Take(search.PerPage)
                             .Select(conversion)
                             .ToList()
            };
        }
    }
}
