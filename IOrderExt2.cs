using System.Collections.Generic;
using System.Linq;

public static class IOrderExt2
{
    public static IOrder2 Update(this IOrder2 order)
    {
        foreach (var item in order.Items)
        {
            item.Update();
        }

        if (order is IHasDiscounts o)
        {
            if (order is IHasDiscountsWithTotal o2)
            {
                o2.Discounts.Update(order);
            }

            order.Discount = order.Discount();
        }

        order.Total = order.Total();

        return order;
    }

    public static IEnumerable<(double VatRate, decimal SubTotal, decimal Vat, decimal Total)> GetTotals(this IOrder2 order) 
    {
        return order.Items
            .GroupBy(x => x.VatRate, x => x)
            .Select(x => (VatRate: x.Key, SubTotal: x.Sum(i => i.SubTotal()), Vat: x.Sum(i => i.Vat()), Total: x.Sum(i => i.Total)));
    }
}
