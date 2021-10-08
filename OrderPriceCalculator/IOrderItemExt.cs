namespace OrderPriceCalculator;

public static class IOrderItemExt
{
    /// <summary>
    /// Get total price excl. VAT, charges and discounts
    /// </summary>
    /// <param name="orderItem"></param>
    /// <returns></returns>
    public static decimal SubTotal(this IOrderItem orderItem)
    {
        var chargeWithoutVat = orderItem
                       .Charge().GetValueOrDefault()
                       .SubtractVat(orderItem.VatRate);

        var discountWithoutVat = orderItem
             .Discount().GetValueOrDefault()
             .SubtractVat(orderItem.VatRate);

        var value = (orderItem.Price * (decimal)orderItem.Quantity).SubtractVat(orderItem.VatRate) + chargeWithoutVat + discountWithoutVat;

        return Math.Round(value, 2);
    }

    public static decimal Vat(this IOrderItem orderItem)
    {
        var chargeVat = orderItem
               .Charge().GetValueOrDefault()
               .GetVatIncl(orderItem.VatRate);

        var discountVat = orderItem
               .Discount().GetValueOrDefault()
               .GetVatIncl(orderItem.VatRate);

        var value = (orderItem.Price * (decimal)orderItem.Quantity).GetVatIncl(orderItem.VatRate) + chargeVat + discountVat;

        return Math.Round(value, 2);
    }

    public static decimal Total(this IOrderItem orderItem, bool withCharge = true, bool withDiscount = true)
    {
        var sum = orderItem.Price * (decimal)orderItem.Quantity;

        if (orderItem is IHasCharges hasCharges && withCharge)
        {
            sum += hasCharges.Charges.Sum(orderItem);
        }

        if (orderItem is IHasDiscounts hasDiscounts && withDiscount)
        {
            sum += hasDiscounts.Discounts.Sum(orderItem);
        }

        return Math.Round(sum, 2);
    }
}