namespace OrderPriceCalculator;

public static class IOrderExt2
{
    public static IOrder2 Update(this IOrder2 order)
    {
        foreach (var item in order.Items)
        {
            item.Update();
        }

        if (order is IOrder2WithTotals o2wt)
        {
            o2wt.UpdateTotals();
        }

        if (order is IHasCharges hasCharges)
        {
            if (order is IHasChargesWithTotal hasChargesWithTotal)
            {
                hasChargesWithTotal.Charges.Update(order);
            }

            order.Charge = order.Charge();
            order.TotalCharge = order.ChargeTotal();
        }

        if (order is IHasDiscounts hasDiscounts)
        {
            if (order is IHasDiscountsWithTotal hasDiscountsWithTotal)
            {
                hasDiscountsWithTotal.Discounts.Update(order);
            }

            order.Discount = order.Discount();
            order.TotalDiscount = order.TotalDiscount();
        }

        order.SubTotal = order.SubTotal();

        order.Rounding = order.Rounding();
        if (order.Rounding == 0) order.Rounding = null;

        order.Total = order.Total();

        return order;
    }

    public static IOrder2 UpdateTotals(this IOrder2WithTotals order)
    {
        if (order is not IOrder2WithTotalsInternals orderWithTotals)
            throw new InvalidOperationException("Order must implement IOrder2WithTotalsInternals");

        var totals = order.Totals();

        if (totals.Count() == 1)
        {
            orderWithTotals.ClearTotals();

            var total = totals.First();

            order.SubTotal = total.SubTotal;
            order.Vat = total.Vat;
            order.VatRate = total.VatRate;

            return order;
        }

        foreach (var total in totals)
        {
            var t = order.Totals.FirstOrDefault(x => x.VatRate == total.VatRate);

            if (t is null)
            {
                t = orderWithTotals.CreateTotals(
                    total.VatRate,
                    total.SubTotal,
                    total.Vat,
                    total.Total
                );

                orderWithTotals.AddTotals(t);
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
                orderWithTotals.RemoveTotals(t);
            }
        }

        order.SubTotal = order.Totals.Sum(i => i.SubTotal);
        order.Vat = order.Totals.Sum(i => i.Vat);
        order.VatRate = null;

        return order;

    }
}