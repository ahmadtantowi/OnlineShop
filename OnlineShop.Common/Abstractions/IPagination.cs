namespace OnlineShop.Common.Abstractions
{
    public interface IPagination
    {
        int Page { get; set; }
        int Size { get; set; }
        int CalculateOffset();
    }
}