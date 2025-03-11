using ProvaPub.Domain.Entities;

namespace ProvaPub.Test.UnitTest.Domain.Entities
{
    public class RandomNumberEntityTest
    {
        [Fact(DisplayName = nameof(ShouldGeneraterandonNumberOnCreateEntity))]
        [Trait("Unit/Entities", "RandonNumber")]
        public void ShouldGeneraterandonNumberOnCreateEntity()
        {
            var randonNumber = new RandomNumberEntity();

            Assert.NotEqual(0, randonNumber.Number);
        }
    }
}
