using System.Collections.Generic;
using OnlineShop.Common.Abstractions;
using OnlineShop.Common.Enums;

namespace OnlineShop.Common.Models
{
    public class CollectionRequest : Pagination, ISearch, IOrderBy, IGetAll
    {
        public string Search { get; set; }
        public IEnumerable<string> SearchBy { get; set; }
        public string OrderBy { get; set; }
        public OrderType? OrderType { get; set; }
        public bool? GetAll { get; set; }

        public bool CanCountWithoutFetchDb(int itemsCount) => (GetAll.HasValue && GetAll.Value) || (Page == 1 && itemsCount < Size);
    }
}