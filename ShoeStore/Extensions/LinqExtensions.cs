namespace ShoeStore.Extensions;

public static class LinqExtensions
{
    public static bool IsBetween(this int price, int fromPrice, int toPrice)
    {
        return price >= fromPrice && price <= toPrice;
    }
}