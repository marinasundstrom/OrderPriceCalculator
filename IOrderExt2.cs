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
}
