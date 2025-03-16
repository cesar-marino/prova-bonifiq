using ProvaPub.Domain.Entities;

namespace ProvaPub.Application.UseCases.Order.Commons
{
    public class OrderResponse(
        Guid orderId,
        decimal amount,
        string orderDate,
        CustomerOrderResponse customer)
    {
        public Guid OrderId { get; } = orderId;
        public decimal Amount { get; } = amount;
        public string OrderDate { get; } = orderDate;
        public CustomerOrderResponse Customer { get; } = customer;

        public static OrderResponse FromEntity(OrderEntity order, CustomerEntity? customer = null)
        {
            var utcDate = DateTime.SpecifyKind(order.OrderDate, DateTimeKind.Utc);
            var utc3 = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            var orderDate = TimeZoneInfo.ConvertTimeFromUtc(utcDate, utc3);

            return new(
                orderId: order.Id,
                amount: order.Amount,
                orderDate: orderDate.ToString("dd/MM/yyyy HH:mm"),
                customer: customer == null
                    ? new(customerId: order.CustomerId)
                    : new(customerId: customer.Id, name: customer.Name));
        }
    }

    public class CustomerOrderResponse(
        Guid customerId,
        string? name = null)
    {
        public Guid CustomerId { get; } = customerId;
        public string? Name { get; } = name;
    }
}
