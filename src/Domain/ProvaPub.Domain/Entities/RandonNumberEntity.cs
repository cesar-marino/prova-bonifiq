using ProvaPub.Domain.SeedWork;

namespace ProvaPub.Domain.Entities
{
    public class RandonNumberEntity : EntityBase
    {
        public int Number { get; }

        public RandonNumberEntity()
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
