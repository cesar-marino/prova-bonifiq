using ProvaPub.Domain.Entities;

namespace ProvaPub.Application.UseCases.Customer.Commons
{
    public class CustomerResponse(
        Guid customerId,
        string name,
        List<CustomerOrderResponse> orders)
    {
        public Guid CustomerId { get; } = customerId;
        public string Name { get; } = name;
        public List<CustomerOrderResponse> Orders { get; } = orders;

        public static CustomerResponse FromEntity(CustomerEntity customer, IReadOnlyList<OrderEntity>? orders = null)
        {
            return new CustomerResponse(
                customerId: customer.Id,
                name: customer.Name,
                orders: orders == null
                    ? [.. customer.Orders.Select(CustomerOrderResponse.FromEntity)]
                    : [.. orders.Select(CustomerOrderResponse.FromEntity)]);
        }
    }

    public class CustomerOrderResponse(
        Guid orderId,
        decimal? value = null,
        DateTime? orderDate = null)
    {
        public Guid OrderId { get; } = orderId;
        public decimal? Value { get; } = value;
        public DateTime? OrderDate { get; } = orderDate;

        public static CustomerOrderResponse FromEntity(Guid orderId) => new(orderId: orderId);

        public static CustomerOrderResponse FromEntity(OrderEntity order) => new(
            orderId: order.Id,
            value: order.Amount,
            orderDate: order.OrderDate);
    }
}
