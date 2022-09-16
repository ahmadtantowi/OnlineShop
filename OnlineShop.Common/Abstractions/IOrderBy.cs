using OnlineShop.Common.Enums;

namespace OnlineShop.Common.Abstractions
{
    public interface IOrderBy
    {
        string OrderBy { get; set; }
        OrderType? OrderType { get; set; }
    }
}