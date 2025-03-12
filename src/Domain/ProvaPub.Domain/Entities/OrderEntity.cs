using ProvaPub.Domain.SeedWork;

namespace ProvaPub.Domain.Entities
{
    public class OrderEntity : EntityBase
    {
        public decimal Value { get; }
        public DateTime OrderDate { get; }

        public OrderEntity(decimal value, DateTime orderDate)
        {
            Value = value;
            OrderDate = orderDate;
        }

        public OrderEntity(Guid orderId, decimal value, DateTime orderDate) : base(orderId)
        {
            Value = value;
            OrderDate = orderDate;
        }
    }
}
