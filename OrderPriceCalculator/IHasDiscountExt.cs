﻿namespace OrderPriceCalculator;

using System;
using System.Linq;

public static class IHasDiscountExt
{
    public static decimal? Discount(this IHasDiscounts hasDiscounts)
    {
        decimal? discount = null;

        if (hasDiscounts is IOrder order)
        {
            foreach (var item in order.Items)
            {
                if (!item.Discounts.Any())
                    continue;

                if (discount is null) discount = 0;

                discount += item.Discount();
            }

            if (order.Discounts.Any())
            {
                discount += order.Discounts.Sum(order);
            }
        }
        else if (hasDiscounts is IOrderItem orderItem)
        {
            if (orderItem.Discounts.Any())
            {
                if (discount is null) discount = 0;

                return orderItem.Discounts.Sum(orderItem);
            }
        }

        return discount;
    }
}
