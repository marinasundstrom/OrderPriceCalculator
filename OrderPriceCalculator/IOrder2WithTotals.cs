namespace OrderPriceCalculator;

using System.Collections.Generic;

public interface IOrder2WithTotals : IOrder2
{
    IEnumerable<IOrderTotals> Totals { get; }
}