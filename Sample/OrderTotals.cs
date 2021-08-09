namespace OrderPriceCalculator.Sample;

public class OrderTotals : IOrderTotals
{
    public double VatRate { get; set; }

    public decimal SubTotal { get; set; }

    public decimal Vat { get; set; }
    
    public decimal Total { get; set; }
}