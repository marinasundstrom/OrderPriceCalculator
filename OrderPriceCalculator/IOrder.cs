namespace OrderPriceCalculator;

using System.Collections.Generic;

public interface IOrder : IHasDiscounts
{
    IEnumerable<IOrderItem> Items { get; }
}
