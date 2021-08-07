namespace OrderPriceCalculator;

public interface IOrderItem2 : IOrderItem, IHasDiscountsWithTotal
{
    decimal Vat { get; set; }

    decimal Total { get; set; }
}
