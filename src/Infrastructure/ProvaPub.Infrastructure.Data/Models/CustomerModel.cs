using ProvaPub.Domain.Entities;

namespace ProvaPub.Infrastructure.Data.Models
{
    public class CustomerModel
    {
        public Guid CustomerId { get; }
        public string Name { get; }

        public virtual List<OrderModel>? Orders { get; }

        public CustomerModel(
            Guid customerId,
            string name)
        {
            CustomerId = customerId;
            Name = name;
        }

        public static CustomerModel FromEntity(CustomerEntity customer) => new(
            customerId: customer.Id,
            name: customer.Name);

        public CustomerEntity ToEntity() => new(
            customerId: CustomerId,
            name: Name);

#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere adicionar o modificador "obrigatório" ou declarar como anulável.
        protected CustomerModel() { }
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere adicionar o modificador "obrigatório" ou declarar como anulável.
    }
}
