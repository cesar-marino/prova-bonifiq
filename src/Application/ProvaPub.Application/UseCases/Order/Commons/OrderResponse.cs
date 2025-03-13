using ProvaPub.Domain.Entities;

namespace ProvaPub.Application.UseCases.Order.Commons
{
    public class OrderResponse(
        Guid orderId,
        decimal amount,
        DateTime orderDate,
        CustomerOrderResponse customer)
    {
        public Guid OrderId { get; } = orderId;
        public decimal Amount { get; } = amount;
        public DateTime OrderDate { get; } = orderDate;
        public CustomerOrderResponse Customer { get; } = customer;

        public static OrderResponse FromEntity(OrderEntity order, CustomerEntity? customer = null) => new(
            orderId: order.Id,
            amount: order.Amount,
            orderDate: order.OrderDate,
            customer: customer == null
                ? new(customerId: order.CustomerId)
                : new(customerId: customer.Id, name: customer.Name));
    }

    public class CustomerOrderResponse(
        Guid customerId,
        string? name = null)
    {
        public Guid CustomerId { get; } = customerId;
        public string? Name { get; } = name;
    }
}
