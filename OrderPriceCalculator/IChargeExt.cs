namespace OrderPriceCalculator;

public static class IChargeExt
{
    public static decimal Total(this ICharge charge, IOrderItem orderItem)
    {
        // Standard is to apply the Charge once for every Order Item.

        int chargeQuantity = 1;

        if (charge.Quantity == null && charge.Limit != null)
        {
            throw new InvalidOperationException("Quantity must be specified when Limit is set.");
        }

        if (charge.Quantity != null)
        {
            // Apply Charge to a certain Quantity. Respecting the Limit telling how many times.

            var orderItemQuantity = orderItem.Quantity;

            if (orderItem.Quantity > (charge.Limit * charge.Quantity))
            {
                orderItemQuantity = charge.Quantity.GetValueOrDefault();
            }

            chargeQuantity = (int)Math.Floor(orderItemQuantity / (double)charge.Quantity);
        }

        if (charge.Percent is not null)
        {
            return (decimal)charge.Percent.GetValueOrDefault() * orderItem.Total(withDiscount: false, withCharge: false) * (decimal)chargeQuantity;
        }

        return charge.Amount.GetValueOrDefault() * (decimal)chargeQuantity;
    }

    public static decimal Total(this ICharge charge, IOrder order)
    {
        if (charge.Quantity != null)
        {
            throw new NotSupportedException();
        }

        if (charge.Percent is not null)
        {
            var total = order.TotalCore();
            return (decimal)charge.Percent.GetValueOrDefault() * total;
        }

        return charge.Amount.GetValueOrDefault();
    }

    public static decimal Sum(this IEnumerable<ICharge> charges, IOrderItem orderItem)
    {
        return orderItem.Charges.Sum(d => d.Total(orderItem));
    }

    public static decimal Sum(this IEnumerable<ICharge> charges, IOrder order)
    {
        return order.Charges.Sum(d => d.Total(order));
    }
}