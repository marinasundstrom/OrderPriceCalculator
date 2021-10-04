Feature: Price Calculator
 
Calculates the price for Orders
 
Scenario: Calculate Total for OrderItem
Calculates the SubTotal, Vat, and Total for an OrderItem.

Given that the Unit Price is <Price>
And the VAT Rate is <VatRate>
And the Quantity is <Quantity>
Then the SubTotal should be <SubTotal>
And the VAT should be <Vat>
And the Total should be <Total>

Examples:
| Price | VatRate | Quantity | SubTotal | Vat   | Total |
| 100   | 0.25    | 1        | 80       | 20    | 100   |
| 100   | 0.25    | 2        | 160      | 40    | 200   |
| 12.90 | 0.12    | 1        | 11.52    | 1.38  | 12.90 |
| 12.90 | 0.12    | 2        | 23.04    | 2.76  | 25.80 |


Scenario: Calculate Total for Order
Calculates the SubTotal, Vat, Rounding, and Total for an Order.

Given the following Order Items
| Price | VatRate | Quantity |
| 12.90 | 0.12    | 2        |
| 100   | 0.25    | 1        |

Then the SubTotal should be 103.04
And the VAT should be 22.76
And the Rounding should be 0.20
And the Total should be 126