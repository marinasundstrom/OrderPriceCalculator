namespace OrderPriceCalculator;

public interface IOrder : IHasCharges, IHasDiscounts, IHasChargeTotal, IHasDiscountTotal
{
    IEnumerable<IOrderItem> Items { get; }
}