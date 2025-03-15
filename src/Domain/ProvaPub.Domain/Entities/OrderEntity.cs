using ProvaPub.Domain.Exceptions;
using ProvaPub.Domain.SeedWork;

namespace ProvaPub.Domain.Entities
{
    public class OrderEntity : EntityBase
    {
        public Guid CustomerId { get; }
        public decimal Amount { get; }
        public DateTime OrderDate { get; }

        public OrderEntity(
            Guid customerId,
            decimal amount,
            DateTime? orderDate = null)
        {
            CustomerId = customerId;
            Amount = amount;
            OrderDate = orderDate ?? DateTime.Now;

            Validate();
        }

        public OrderEntity(
            Guid orderId,
            Guid customerId,
            decimal amount,
            DateTime orderDate) : base(orderId)
        {
            CustomerId = customerId;
            Amount = amount;
            OrderDate = orderDate;
        }

        private void Validate()
        {
            if (Amount <= 0)
                throw new EntityValidationException(message: "O valor da compra deve ser maior que zero");
        }
    }
}
