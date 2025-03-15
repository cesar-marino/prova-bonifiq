namespace ProvaPub.Domain.Specifications
{
    public abstract class CompositeSpecification<T> : ISpecification<T>
    {
        private readonly List<ISpecification<T>> _specifications = [];

        public string ErrorMessage { get; private set; } = string.Empty;

        public void AddSpecification(ISpecification<T> specification) => _specifications.Add(specification);

        public bool IsSatisfiedBy(T obj)
        {
            foreach (var spec in _specifications)
            {
                if (!spec.IsSatisfiedBy(obj))
                {
                    ErrorMessage = spec.ErrorMessage;
                    return false;
                }
            }

            return true;
        }
    }
}
