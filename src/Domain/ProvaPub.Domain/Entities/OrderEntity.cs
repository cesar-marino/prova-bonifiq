using ProvaPub.Domain.SeedWork;

namespace ProvaPub.Domain.Entities
{
    public class OrderEntity : EntityBase
    {
        public Guid CustomerId { get; }
        public decimal Value { get; }
        public DateTime OrderDate { get; }

        public OrderEntity(Guid customerId, decimal value, DateTime? orderDate = null)
        {
            CustomerId = customerId;
            Value = value;
            OrderDate = orderDate ?? DateTime.Now;
        }

        public OrderEntity(Guid orderId, Guid customerId, decimal value, DateTime orderDate) : base(orderId)
        {
            CustomerId = customerId;
            Value = value;
            OrderDate = orderDate;
        }
    }
}
