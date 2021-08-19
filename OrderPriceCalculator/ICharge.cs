namespace OrderPriceCalculator;

public interface ICharge
{
    string Description { get; set; }

    int? Quantity { get; set; }

    int? Limit { get; set; }

    decimal? Amount { get; set; }

    double? Percent { get; set; }
}