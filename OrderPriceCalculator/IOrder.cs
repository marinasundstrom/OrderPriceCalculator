namespace OrderPriceCalculator;

public interface IOrder : IHasDiscounts
{
    IEnumerable<IOrderItem> Items { get; }
}