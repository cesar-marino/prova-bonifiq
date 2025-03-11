using ProvaPub.Domain.SeedWork;

namespace ProvaPub.Domain.Entities
{
    public class RandomNumberEntity : EntityBase
    {
        public int Number { get; }

        public RandomNumberEntity()
        {
            Number = GenerateRandonNumber();
        }

        public int GenerateRandonNumber()
        {
            var randon = new Random(Id.GetHashCode());
            return randon.Next();
        }
    }
}
