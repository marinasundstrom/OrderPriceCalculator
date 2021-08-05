using System;
using System.Linq;

public static class IOrderExt
{
    public static decimal SubTotal(this IOrder order)
    {
        return order.TotalCore();
    }

    public static decimal Vat(this IOrder order)
    {
        return order.Items.Sum(i => i.Vat());
    }

    public static decimal Rounding(this IOrder order)
    {
        var totalBeforeRounding = order.Total(false);
        return Math.Round(totalBeforeRounding) - totalBeforeRounding;
    }

    public static decimal Total(this IOrder order, bool withRounding = true, bool withDiscount = true)
    {
        decimal total = order.TotalCore();

        if (order is IHasDiscounts o && withDiscount)
        {
            total += o.Discounts.Sum(order);
        }

        if (withRounding)
        {
            total += order.Rounding();
        }

        return total;
    }

    public static decimal TotalCore(this IOrder order)
    {
        return order.Items.Sum(i => i.Total());
    }
}
