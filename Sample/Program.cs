using OrderPriceCalculator.Sample;

//var price = 100m.AddVat(0.25);
//var vat = price.GetVatIncl(0.25);
//var price2 = price.SubtractVat(0.25);

CultureInfo? culture = new("sv-SE");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

Order order;

//order = CreateOrder();
//order = CreateOrder2();
//order = CreateOrder3();
order = CreateOrder4();

order.Update();
order.Dump();

Order CreateOrder()
{
    var order = new Order();
    order.Items.AddRange(new OrderItem[] {
        new ()
        {
            Description = "Kebabtallrik",
            Price = 69.00m,
            VatRate = 0.12,
            Quantity = 1
        },
        new ()
        {
            Description = "Kebabtallrik",
            Price = 69.00m,
            VatRate = 0.12,
            Quantity = 1
        },
        new ()
        {
            Description = "Coca Cola Zero",
            Price = 15.00m,
            VatRate = 0.12,
            Quantity = 1
        }
    });

    order.Charges.Add(
        new OrderCharge
        {
            Description = "Tip",
            Percent = 0.15
        }
    );

    return order;
}

Order CreateOrder2()
{
    var order = new Order();
    order.Items.Add(new OrderItem()
    {
        Description = "Coca Cola Zero Flaska 0,5 l",
        Price = 12.90m,
        VatRate = 0.12,
        Quantity = 4,
        Discounts = new List<OrderDiscount>() {
           new OrderDiscount {
               Description = "2 for 1",
               Quantity = 2,
               //Limit = 1,
               Amount = -12.90m
           }
        },
        Charges = new List<OrderCharge>() {
            new OrderCharge {
                Description = "Pant",
                Amount = 2
            },
        }
    });

    return order;
}

Order CreateOrder3()
{
    var order = new Order();
    order.Items.Add(new OrderItem()
    {
        Description = "Skjorta",
        Price = 150m,
        VatRate = 0.25,
        Quantity = 7,
        Discounts = new List<OrderDiscount>() {
             new OrderDiscount {
                 Description = "3 for 2",
                 Quantity = 3,
                 //Limit = 1,
                 Amount = -150
             }
         }
    });

    return order;
}

Order CreateOrder4()
{
    var order = new Order();
    order.Items.AddRange(new OrderItem[] {
        new ()
        {
            Description = "Skjorta",
            Price = 150m,
            VatRate = 0.25,
            Quantity = 3,
            Discounts = new List<OrderDiscount>() {
                new OrderDiscount {
                    Description = "3 for 2",
                    Quantity = 3,
                    Amount = -150
                }
            }
        },
        new ()
        {
            Description = "Mjolk",
            Price = 7.90m,
            VatRate = 0.12,
            Quantity = 1
        },
        new ()
        {
            Description = "Kaffe",
            Price = 24m,
            VatRate = 0.12,
            Quantity = 1,
            Discounts = new List<OrderDiscount>()
            {
                new ()
                {
                    Description = "Discount",
                    Percent = -0.10
                }
            }
        },
    });

    return order;
}