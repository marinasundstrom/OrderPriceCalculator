namespace OrderPriceCalculator;

public interface IDiscountWithTotal : IDiscount
{
    decimal Total { get; set; }
}