namespace ProvaPub.Application.UseCases.Order.Commons
{
    public class OrderResponse(
        Guid orderId,
        decimal value,
        DateTime orderDate)
    {
        public Guid OrderId { get; } = orderId;
        public decimal Value { get; } = value;
        public DateTime OrderDate { get; } = orderDate;
    }
}
