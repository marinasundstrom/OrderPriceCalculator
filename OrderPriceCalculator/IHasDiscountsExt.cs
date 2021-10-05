namespace OrderPriceCalculator;

public static class IHasDiscountsExt
{
    /// <summary>
    /// Gets the total amount of Discounts.
    /// </summary>
    public static decimal? Discount(this IHasDiscounts hasDiscounts)
    {
        decimal? discount = null;

        if (hasDiscounts is IOrder order)
        {
            foreach (var item in order.Items)
            {
                if (!item.Discounts.Any())
                    continue;

                if (discount is null) discount = 0;

                discount += item.Discount();
            }

            if (order.Discounts.Any())
            {
                if (discount is null) discount = 0;

                discount += order.Discounts.Sum(order);
            }
        }
        else if (hasDiscounts is IOrderItem orderItem)
        {
            if (orderItem.Discounts.Any())
            {
                if (discount is null) discount = 0;

                return orderItem.Discounts.Sum(orderItem);
            }
        }

        return discount;
    }

    /// <summary>
    /// Get discounts at an Order-level.
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    public static decimal? OrderDiscounts(this IOrder order)
    {
        decimal? discount = null;

        if (order.Discounts.Any())
        {
            if (discount is null) discount = 0;

            discount += order.Discounts.Sum(order);
        }

        return discount;
    }
}