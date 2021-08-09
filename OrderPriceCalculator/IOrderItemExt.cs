namespace OrderPriceCalculator;

using System.Linq;

public static class IOrderItemExt
{
    public static decimal SubTotal(this IOrderItem orderItem)
    {
        var discountWithoutVat = orderItem
             .Discount().GetValueOrDefault()
             .SubtractVat(orderItem.VatRate);

        return (decimal)orderItem.Quantity * orderItem.Price.SubtractVat(orderItem.VatRate) + discountWithoutVat;

    }

    public static decimal Vat(this IOrderItem orderItem)
    {
        var discountVat = orderItem
               .Discount().GetValueOrDefault()
               .GetVatIncl(orderItem.VatRate);

        var v = (orderItem.Price * (decimal)orderItem.Quantity).GetVatIncl(orderItem.VatRate) + discountVat;

        return v; ;
    }

    public static decimal Total(this IOrderItem orderItem, bool withDiscount = true)
    {
        var sum = orderItem.Price * (decimal)orderItem.Quantity;

        if (withDiscount)
        {
            if (orderItem is IHasDiscounts oi && withDiscount)
            {
                sum += oi.Discounts.Sum(orderItem);
            }
        }

        return sum;
    }
}