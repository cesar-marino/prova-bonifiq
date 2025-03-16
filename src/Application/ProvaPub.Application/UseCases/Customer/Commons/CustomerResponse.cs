using ProvaPub.Domain.Entities;

namespace ProvaPub.Application.UseCases.Customer.Commons
{
    public class CustomerResponse(
        Guid customerId,
        string name,
        List<OrderCustomerResponse> orders)
    {
        public Guid CustomerId { get; } = customerId;
        public string Name { get; } = name;
        public List<OrderCustomerResponse> Orders { get; } = orders;

        public static CustomerResponse FromEntity(CustomerEntity customer, IReadOnlyList<OrderEntity>? orders = null)
        {
            return new CustomerResponse(
                customerId: customer.Id,
                name: customer.Name,
                orders: orders == null
                    ? [.. customer.Orders.Select(OrderCustomerResponse.FromEntity)]
                    : [.. orders.Select(OrderCustomerResponse.FromEntity)]);
        }
    }

    public class OrderCustomerResponse(
        Guid orderId,
        decimal? value = null,
        DateTime? orderDate = null)
    {
        public Guid OrderId { get; } = orderId;
        public decimal? Value { get; } = value;
        public DateTime? OrderDate { get; } = orderDate;

        public static OrderCustomerResponse FromEntity(Guid orderId) => new(orderId: orderId);

        public static OrderCustomerResponse FromEntity(OrderEntity order) => new(
            orderId: order.Id,
            value: order.Amount,
            orderDate: order.OrderDate);
    }
}
