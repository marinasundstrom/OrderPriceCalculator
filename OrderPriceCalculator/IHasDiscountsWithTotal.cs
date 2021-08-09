namespace OrderPriceCalculator;

using System.Collections.Generic;

public interface IHasDiscountsWithTotal : IHasDiscounts
{
    new IEnumerable<IDiscountWithTotal> Discounts { get; }
}