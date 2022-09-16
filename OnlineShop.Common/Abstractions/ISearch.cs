using System.Collections.Generic;

namespace OnlineShop.Common.Abstractions
{
    public interface ISearch
    {
        string Search { get; set; }
        IEnumerable<string> SearchBy { get; set; }
    }
}