using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.RequestFeatures
{
    public class PagedResponse<T>
    {
        public MetaData MetaData { get; init; }
        public List<T> Items { get; init; }

        public PagedResponse(List<T> items, int count, int pageNumber, int pageSize)
        {
            Items = items;

            MetaData = new MetaData()
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPage = (int)Math.Ceiling(count / (double)pageSize)

            };       
            
        }
        public PagedResponse(List<T> items, MetaData metaData)
        {
            Items = items;
            MetaData = metaData;
        }


        public static async Task<PagedResponse<T>> ToPagedResponse(IQueryable<T> query, int pageNumber, int pageSize)
        {
            var count = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResponse<T>(items, count, pageNumber, pageSize);
        }

    }
}
