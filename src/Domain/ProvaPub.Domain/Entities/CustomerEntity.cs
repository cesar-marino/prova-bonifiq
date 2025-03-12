using ProvaPub.Domain.SeedWork;

namespace ProvaPub.Domain.Entities
{
    public class CustomerEntity : EntityBase
    {
        public string Name { get; }

        private readonly List<Guid> _orders;
        public IReadOnlyList<Guid> Orders => _orders;

        public CustomerEntity(string name)
        {
            _orders = [];
            Name = name;
        }

        public CustomerEntity(Guid customerId, string name) : base(customerId)
        {
            _orders = [];
            Name = name;
        }
    }
}
