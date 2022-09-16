using System.Collections.Generic;
using OnlineShop.Common.Models;

namespace OnlineShop.Common.Extensions
{
    public static class DictionaryExtension
    {
        public static IDictionary<string, object> AddPaginationProperty(this IDictionary<string, object> dictionary, PaginationProperty pagination)
        {
            dictionary.Add(nameof(pagination.Page), pagination.Page);
            dictionary.Add(nameof(pagination.Size), pagination.Size);
            dictionary.Add(nameof(pagination.TotalPage), pagination.TotalPage);
            dictionary.Add(nameof(pagination.TotalItem), pagination.TotalItem);

            return dictionary;
        }

        public static PaginationProperty GetPaginationProperty(this IDictionary<string, object> dictionary)
        {
            var pagination = new PaginationProperty();
            if (dictionary.TryGetValue("page", out var obj) && int.TryParse(obj.ToString(), out var page))
                pagination.Page = page;
            if (dictionary.TryGetValue("size", out obj) && int.TryParse(obj.ToString(), out var size))
                pagination.Size = size;
            if (dictionary.TryGetValue("totalItem", out obj) && int.TryParse(obj.ToString(), out var totalItem))
                pagination.TotalItem = totalItem;
                
            return pagination;
        }

        public static IDictionary<string, object> AddColumnProperty(this IDictionary<string, object> dictionary, params string[] columns)
        {
            dictionary.Add("Columns", columns);
            
            return dictionary;
        }
    }
}