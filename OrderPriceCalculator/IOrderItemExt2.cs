namespace OrderPriceCalculator;

public static class IOrderItemExt2
{
    public static IOrderItem2 Update(this IOrderItem2 orderItem)
    {
        orderItem.Vat = orderItem.Vat();
        orderItem.Total = orderItem.Total();

        if (orderItem is IHasCharges hasCharges)
        {
            if (orderItem is IHasChargesWithTotal hasChargesWithTotal)
            {
                hasChargesWithTotal.Charges.Update(orderItem);
            }

            if (hasCharges.Charges.Any())
            {
                orderItem.Charge = hasCharges.Charges.Sum(orderItem);
            }
        }

        if (orderItem is IHasDiscounts hasDiscounts)
        {
            if (orderItem is IHasDiscountsWithTotal hasDiscountsWithTotal)
            {
                hasDiscountsWithTotal.Discounts.Update(orderItem);
            }

            if (hasDiscounts.Discounts.Any())
            {
                orderItem.Discount = hasDiscounts.Discounts.Sum(orderItem);
            }
        }

        return orderItem;
    }
}