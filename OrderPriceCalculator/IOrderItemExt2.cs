namespace OrderPriceCalculator;

using System.Linq;

public static class IOrderItemExt2
{
    public static IOrderItem2 Update(this IOrderItem2 orderItem)
    {
        orderItem.Vat = orderItem.Vat();
        orderItem.Total = orderItem.Total();

        if (orderItem is IHasDiscounts oi)
        {
            if (orderItem is IHasDiscountsWithTotal oi2)
            {
                oi2.Discounts.Update(orderItem);
            }

            if (oi.Discounts.Any())
            {
                orderItem.Discount = oi.Discounts.Sum(orderItem);
            }
        }

        return orderItem;
    }
}