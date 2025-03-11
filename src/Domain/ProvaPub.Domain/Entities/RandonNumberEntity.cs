using ProvaPub.Domain.SeedWork;

namespace ProvaPub.Domain.Entities
{
    public class RandonNumberEntity : EntityBase
    {
        public int Number { get; }

        public RandonNumberEntity(int number) => Number = number;

        public RandonNumberEntity(Guid randonNumberId, int number) : base(randonNumberId)
        {
            Number = number;
        }
    }
}
