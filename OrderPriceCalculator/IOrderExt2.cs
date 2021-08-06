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

        if(order is IOrder2WithTotals owt)
        {
            owt.UpdateTotals();
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

    public static IOrder2 UpdateTotals(this IOrder2WithTotals order)
    {
        var totals = order.Totals();

        if (totals.Count() == 1)
        {
            (order.Totals as List<OrderTotals>)!.Clear();

            var total = totals.First();

            order.SubTotal = total.SubTotal;
            order.Vat = total.Vat;
            order.VatRate = total.VatRate;

            return order;
        }

        foreach (var total in totals)
        {
            var t = order.Totals.FirstOrDefault(x => x.VatRate == total.VatRate);

            if (t == null)
            {
                t = new OrderTotals()
                {
                    VatRate = total.VatRate,
                    SubTotal = total.SubTotal,
                    Vat = total.Vat,
                    Total = total.Total
                };

                (order.Totals as List<OrderTotals>)!.Add((OrderTotals)t);
            }
            else
            {
                t.VatRate = total.VatRate;
                t.SubTotal = total.SubTotal;
                t.Vat = total.Vat;
                t.Total = total.Total;
            }
        }

        foreach (var t in order.Totals.ToList())
        {
            var total = totals.FirstOrDefault(x => x.VatRate == t.VatRate);

            if (total == default)
            {
                (order.Totals as List<OrderTotals>)!.Remove((OrderTotals)t);
            }
        }

        return order;

    }
}
