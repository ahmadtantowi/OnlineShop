using System.Collections.Generic;
using System.Linq;
using OnlineShop.Common.Abstractions;
using OnlineShop.Common.Models;

namespace OnlineShop.Common.Extensions
{
    public static class PaginationExtension
    {
        public static IDictionary<string, object> CreatePaginationProperty<T>(this T pagination, long totalItems)
            where T : IGetAll
        {
            var paginationProp = new PaginationProperty
            {
                Page = pagination.Page,
                Size = pagination.GetAll.HasValue && pagination.GetAll.Value 
                    ? (int)totalItems 
                    : pagination.Size,
                TotalItem = totalItems
            };
            
            return paginationProp.ToDictionary();
        }

        public static IDictionary<string, object> ToDictionary(this PaginationProperty pagination)
        {
            return new Dictionary<string, object>
            {
                { nameof(pagination.Page), pagination.Page },
                { nameof(pagination.Size), pagination.Size },
                { nameof(pagination.TotalPage), pagination.TotalPage },
                { nameof(pagination.TotalItem), pagination.TotalItem }
            };
        }
    }
}