namespace ProvaPub.Domain.Specifications
{
    public class CompositeSpecification<TEntity>
    {
        private readonly List<ISpecification<TEntity>> _specifications = [];

        public void AddSpecification(ISpecification<TEntity> specification) => _specifications.Add(specification);

        public bool IsSatisfiedBy(TEntity entity)
        {
            foreach (var spec in _specifications)
            {
                if (!spec.IsSatisfiedBy(entity))
                    return false;
            }

            return true;
        }
    }
}
