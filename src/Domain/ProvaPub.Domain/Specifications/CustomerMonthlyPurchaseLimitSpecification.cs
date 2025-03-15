using ProvaPub.Domain.Entities;

namespace ProvaPub.Domain.Specifications
{
    public class CustomerMonthlyPurchaseLimitSpecification : ISpecification<List<OrderEntity>>
    {
        public string ErrorMessage => throw new NotImplementedException();

        public bool IsSatisfiedBy(List<OrderEntity> obj)
        {
            throw new NotImplementedException();
        }
    }
}
