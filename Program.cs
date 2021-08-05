using System;
using System.Collections.Generic;
using System.Linq;

var price = 100m.AddVat(0.25);
var vat = price.GetVatIncl(0.25);
var price2 = price.SubtractVat(0.25);

var order = new Order();
order.Items.Add(new OrderItem()
{
    Description = "Skjorta",
    Price = 150m,
    VatRate = 0.25,
    Quantity = 3,
    Discounts = new List<Discount>() {
        new Discount {
            Description = "3 for 2",
            Amount = -150
        }
    }
});
//order.Items.Add(new OrderItem()
//{
//    Description = "Skjorta",
//    Price = 150m,
//    VatRate = 0.25,
//    Quantity = 3,
//    Discounts = new List<Discount>() {
//        new Discount {
//            Description = "3 for 2",
//            Amount = -150
//        }
//    }
//});
//order.Items.Add(new OrderItem()
//{
//    Description = "Mjolk",
//    Price = 7.90m,
//    VatRate = 0.12,
//    Quantity = 1
//});
order.Items.Add(new OrderItem()
{
    Description = "Kaffe",
    Price = 24m,
    VatRate = 0.12,
    Quantity = 1
});

//order.Discounts.Add(new Discount
//{
//    Description = "Discount",
//    Percent = -0.10
//});


order.Update();

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

var foo = order.Items
    .GroupBy(x => x.VatRate, x => x)
    .Select(x => (VatRate: x.Key, SubTotal: x.Sum(i => i.SubTotal()), Vat: x.Sum(i => i.Vat()), Total: x.Sum(i => i.Total)));

foreach(var f in foo)
{
    Console.WriteLine($"{f.VatRate * 100}% {f.SubTotal.ToString("c")} {f.Vat.ToString("c")} {f.Total.ToString("c")}");
}

Console.WriteLine();

Console.WriteLine($"Discount: {order.Discount?.ToString("c")}");
Console.WriteLine($"Vat: {order.Vat().ToString("c")}");
Console.WriteLine($"Rounding: {order.Rounding?.ToString("c")} ");
Console.WriteLine($"Total: {order.Total().ToString("c")}");
