using ProvaPub.Domain.Entities;

namespace ProvaPub.Infrastructure.Data.Models
{
    public class OrderModel
    {
        public Guid OrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; }

        public Guid CustomerId { get; set; }
        public virtual CustomerModel? Customer { get; set; }

        public OrderModel(
            Guid orderId,
            decimal amount,
            DateTime orderDate,
            Guid customerId)
        {
            OrderId = orderId;
            Amount = amount;
            OrderDate = orderDate;
            CustomerId = customerId;
        }

        public static OrderModel FromEntity(OrderEntity order) => new(
            orderId: order.Id,
            amount: order.Amount,
            orderDate: order.OrderDate,
            customerId: order.CustomerId);

        public OrderEntity ToEntity() => new(
            orderId: OrderId,
            customerId: CustomerId,
            amount: Amount,
            orderDate: OrderDate);

        protected OrderModel() { }
    }
}
