namespace OrderPriceCalculator;

using System.Collections.Generic;

public interface IOrder2WithTotalsInternals : IOrder2WithTotals
{
    void AddTotals(IOrderTotals orderTotals);

    void RemoveTotals(IOrderTotals orderTotals);

    void ClearTotals();

    IOrderTotals CreateTotals(double vatRate, decimal subTotal, decimal vat, decimal total);
}