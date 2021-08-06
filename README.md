# Order Price Calculator

This is an implementation of a re-usable set of operations and calculations on Order-like entities.

## How to use

As long as your entity classes extend the interfaces you should be able to call the operations to calculate values and update the entities.

## Contents

This project provides interfaces and extension methods that operate on a data model consisiting of the following entities:

* Order (IOrder)
* OrderItem (IOrderItem)
* Discount (IDiscount)

Making it easy to re-use the operations, for example, for functionality that deals with invoices. Just implement the interfaces in your own concrete data model to get access to the methods.

Invoking the extension methods defined for the entities will give you the desired result.

### VAT Rates

Items can be of different VAT Rates. Then they will be calculated as separate "OrderTotals". Then they will not be summarized in the Order's SubTotal, Vat, and VatRate.

### Discounts

The model supports two kind of discounts: Discount of items and Discount on Order (equivalent to Sale). They can be either a negative amount or negative percentage of the Total an Order or OrderItem.

Discounts get summarized in the Discount property.

## Sample

```c#
using System;
using System.Collections.Generic;
using System.Linq;

// Define your order and discounts

var order = new Order();
order.Items.Add(new OrderItem()
{
    Description = "Shirt",
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

order.Items.Add(new OrderItem()
{
    Description = "Coffee",
    Price = 24m,
    VatRate = 0.12,
    Quantity = 1
});

// Will update the calculated state
order.Update();

// "Total" has been update by the "Update" method
Console.WriteLine(order.Total);

// Now you can persist the entity in a DB using, for instance, EF Core.

// Dump to console
order.Dump();
```

Note: Swedish General VAT is 25% for most goods and services. 12% for food, drinks, and such.

**Output:**

```
Shirt 150.00 kr (25%) x 3 pcs = 450.00 kr
    3 for 2  -150.00 kr

Coffee 24.00 kr (12%) x 1 pcs = 24.00 kr


25% 240.00 kr 60.00 kr 300.00 kr
12% 21.43 kr 2.57 kr 24.00 kr

Discount: -150.00 kr
Vat: 62.57 kr
Rounding:  
Total: 324.00 kr
```

## API

The API can be seen as consisting of 2 levels, or layers.

### Layer 1

Adds interfaces with the necessary properties and operations for performing calculations; Price, Quantity etc.

### Layer 2

Extens Layer 1 with interfaces containing properties and methods for persisting the results of the calculations; SubTotal, Total etc.

The ```Update``` methods.