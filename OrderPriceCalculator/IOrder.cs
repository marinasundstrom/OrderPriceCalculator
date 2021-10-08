namespace OrderPriceCalculator;

public interface IOrder : IHasCharges, IHasDiscounts, IHasTotalCharges, IHasTotalDiscounts
{
    IEnumerable<IOrderItem> Items { get; }
}