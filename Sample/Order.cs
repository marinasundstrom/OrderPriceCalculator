namespace OrderPriceCalculator.Sample;

public class Order : IOrder2WithTotals, IOrder2WithTotalsInternals
{
    public int Id { get; set; }
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();

    public decimal? SubTotal { get; set; }
    public double? VatRate { get; set; }
    public decimal? Vat { get; set; }

    public decimal? Rounding { get; set; }
    public decimal Total { get; set; }

    public List<OrderTotals> Totals { get; set; } = new List<OrderTotals>();

    public List<OrderDiscount> Discounts { get; set; } = new List<OrderDiscount>();
    public decimal? Discount { get; set; }
    public decimal? DiscountTotal { get; set; }

    IEnumerable<IOrderItem> IOrder.Items => Items;
    IEnumerable<IOrderItem2> IOrder2.Items => Items;

    IEnumerable<IOrderTotals> IOrder2WithTotals.Totals => Totals;

    IEnumerable<IDiscount> IHasDiscounts.Discounts => Discounts;
    IEnumerable<IDiscountWithTotal> IHasDiscountsWithTotal.Discounts => Discounts;

    public List<OrderCharge> Charges { get; set; } = new List<OrderCharge>();
    public decimal? Charge { get; set; }
    public decimal? ChargeTotal { get; set; }

    IEnumerable<ICharge> IHasCharges.Charges => Charges;
    IEnumerable<IChargeWithTotal> IHasChargesWithTotal.Charges => Charges;

    void IOrder2WithTotalsInternals.AddTotals(IOrderTotals orderTotals)
    {
        Totals.Add((OrderTotals)orderTotals);
    }

    void IOrder2WithTotalsInternals.RemoveTotals(IOrderTotals orderTotals)
    {
        Totals.Remove((OrderTotals)orderTotals);
    }

    void IOrder2WithTotalsInternals.ClearTotals()
    {
        Totals.Clear();
    }

    IOrderTotals IOrder2WithTotalsInternals.CreateTotals(double vatRate, decimal subTotal, decimal vat, decimal total)
    {
        return new OrderTotals()
        {
            VatRate = vatRate,
            SubTotal = subTotal,
            Vat = vat,
            Total = total
        };
    }
}