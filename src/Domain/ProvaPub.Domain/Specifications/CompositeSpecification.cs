namespace ProvaPub.Domain.Specifications
{
    public class CompositeSpecification<TEntity>
    {
        private readonly List<ISpecification<TEntity>> _specifications = [];
        private readonly List<IGlobalSpecification> _globalSpecifications = [];

        public void AddSpecification(ISpecification<TEntity> specification) => _specifications.Add(specification);

        public void AddGlobalSpecification(IGlobalSpecification specification) => _globalSpecifications.Add(specification);

        public bool IsSatisfiedBy(TEntity entity)
        {
            foreach (var spec in _globalSpecifications)
            {
                if (!spec.IsSatisfied())
                    return false;
            }

            foreach (var spec in _specifications)
            {
                if (!spec.IsSatisfiedBy(entity))
                    return false;
            }

            return true;
        }
    }
}
