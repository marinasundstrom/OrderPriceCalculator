namespace OrderPriceCalculator;

public static class IDiscountWithTotalExt
{
    public static IDiscountWithTotal Update(this IDiscountWithTotal discount, IOrder order)
    {
        discount.Total = discount.Total(order);

        return discount;
    }

    public static IDiscountWithTotal Update(this IDiscountWithTotal discount, IOrderItem orderItem)
    {
        discount.Total = discount.Total(orderItem);

        return discount;
    }

    public static void Update(this IEnumerable<IDiscountWithTotal> discounts, IOrder order)
    {
        foreach (var d in discounts)
            d.Update(order);
    }

    public static void Update(this IEnumerable<IDiscountWithTotal> discounts, IOrderItem orderItem)
    {
        foreach (var d in discounts)
            d.Update(orderItem);
    }
}