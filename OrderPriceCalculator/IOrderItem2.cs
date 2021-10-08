namespace OrderPriceCalculator;

public interface IOrderItem2 : IOrderItem, IHasChargesWithTotal, IHasDiscountsWithTotal
{
    //decimal SubTotal { get; set; }

    decimal Vat { get; set; }

    decimal Total { get; set; }
}