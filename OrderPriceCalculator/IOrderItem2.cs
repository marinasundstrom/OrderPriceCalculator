public interface IOrderItem2 : IOrderItem, IHasDiscountsWithTotal
{
    decimal Total { get; set; }
}
