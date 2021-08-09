namespace OrderPriceCalculator;

using System.Collections.Generic;

public interface IHasDiscounts
{
    IEnumerable<IDiscount> Discounts { get; }

    decimal? Discount { get; set; }
}