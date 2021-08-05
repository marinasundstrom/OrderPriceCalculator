using System.Collections.Generic;

public interface IOrder2 : IOrder, IHasDiscountsWithTotal
{
    decimal? Rounding { get; set; }
    decimal Total { get; set; }

    new IEnumerable<IOrderItem2> Items { get; }
}
