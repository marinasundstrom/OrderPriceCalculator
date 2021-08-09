namespace OrderPriceCalculator;

using System.Collections.Generic;
using System.Linq;

public static class IDiscountExt
{
    public static decimal Total(this IDiscount discount, IOrderItem orderItem)
    {
        if (discount.Percent is not null)
        {
            return (decimal)discount.Percent.GetValueOrDefault() * orderItem.Total(withDiscount: false);
        }

        return discount.Amount.GetValueOrDefault();
    }

    public static decimal Total(this IDiscount discount, IOrder order)
    {
        if (discount.Percent is not null)
        {
            var total = order.TotalCore();
            return (decimal)discount.Percent.GetValueOrDefault() * total;
        }

        return discount.Amount.GetValueOrDefault();
    }

    public static decimal Sum(this IEnumerable<IDiscount> discounts, IOrderItem orderItem)
    {
        return orderItem.Discounts.Sum(d => d.Total(orderItem));
    }

    public static decimal Sum(this IEnumerable<IDiscount> discounts, IOrder order)
    {
        return order.Discounts.Sum(d => d.Total(order));
    }
}