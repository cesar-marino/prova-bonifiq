namespace ProvaPub.Domain.Specifications
{
    public class PositivePurchaseAmountSpecification : ISpecification<int>
    {
        public string ErrorMessage => "O valor da compra deve ser maior que zero";

        public bool IsSatisfiedBy(int amount) => amount > 0;
    }
}
