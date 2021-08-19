namespace OrderPriceCalculator;

public static class IChargeWithTotalExt
{
    public static IChargeWithTotal Update(this IChargeWithTotal charge, IOrder order)
    {
        charge.Total = charge.Total(order);

        return charge;
    }

    public static IChargeWithTotal Update(this IChargeWithTotal charge, IOrderItem orderItem)
    {
        charge.Total = charge.Total(orderItem);

        return charge;
    }

    public static void Update(this IEnumerable<IChargeWithTotal> charges, IOrder order)
    {
        foreach (var d in charges)
            d.Update(order);
    }

    public static void Update(this IEnumerable<IChargeWithTotal> charges, IOrderItem orderItem)
    {
        foreach (var d in charges)
            d.Update(orderItem);
    }
}