using ProvaPub.Domain.SeedWork;

namespace ProvaPub.Domain.Entities
{
    public class RandomNumberEntity : EntityBase
    {
        public int Number { get; }

        public RandomNumberEntity()
        {
            Number = GenerateNumber();
        }

        public RandomNumberEntity(
            Guid randomNumberId,
            int number) : base(randomNumberId) => Number = number;

        public int GenerateNumber()
        {
            var randon = new Random(Id.GetHashCode());
            return randon.Next();
        }
    }
}
