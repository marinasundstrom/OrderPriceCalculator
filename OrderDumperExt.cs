using System;
using System.Collections.Generic;
using System.Linq;

public static class OrderDumperExt
{
    public static void Dump(this IOrder2 order)
    {
        foreach (var item in order.Items)
        {
            Console.WriteLine($"{item.Description} {item.Price.ToString("c")} ({item.VatRate * 100}%) x {item.Quantity} pcs = {(item.Total - item.Discount.GetValueOrDefault()).ToString("c")}");

            foreach (var discount in item.Discounts)
            {
                Console.WriteLine($"    {discount.Description} {(discount.Percent is not null ? (item.VatRate * 100) + "%" : null)} {discount.Total.ToString("c")}");
            }

            Console.WriteLine();
        }

        Console.WriteLine();

        var totals = order.Totals();

        foreach(var f in totals)
        {
            Console.WriteLine($"{f.VatRate * 100}% {f.SubTotal.ToString("c")} {f.Vat.ToString("c")} {f.Total.ToString("c")}");
        }

        Console.WriteLine();

        Console.WriteLine($"Discount: {order.Discount?.ToString("c")}");
        Console.WriteLine($"Vat: {order.Vat().ToString("c")}");
        Console.WriteLine($"Rounding: {order.Rounding?.ToString("c")} ");
        Console.WriteLine($"Total: {order.Total().ToString("c")}");    
    }
}
