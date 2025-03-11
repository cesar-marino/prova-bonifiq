namespace ProvaPub.Domain.SeedWork
{
    public abstract class EntityBase
    {
        public Guid Id { get; }

        public EntityBase(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
        }
    }
}
