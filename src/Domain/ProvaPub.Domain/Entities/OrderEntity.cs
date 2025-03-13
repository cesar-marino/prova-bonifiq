using ProvaPub.Domain.SeedWork;

namespace ProvaPub.Domain.Entities
{
    public class OrderEntity : EntityBase
    {
        public decimal Value { get; }
        public DateTime OrderDate { get; }

        public OrderEntity(decimal value, DateTime? orderDate = null)
        {
            Value = value;
            OrderDate = orderDate ?? DateTime.Now;
        }

        public OrderEntity(Guid orderId, decimal value, DateTime orderDate) : base(orderId)
        {
            Value = value;
            OrderDate = orderDate;
        }
    }
}
