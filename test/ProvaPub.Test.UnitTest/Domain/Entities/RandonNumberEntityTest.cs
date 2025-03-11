using ProvaPub.Domain.Entities;

namespace ProvaPub.Test.UnitTest.Domain.Entities
{
    public class RandonNumberEntityTest
    {
        [Fact(DisplayName = nameof(ShouldGeneraterandonNumberOnCreateEntity))]
        [Trait("Unit/Entities", "RandonNumber")]
        public void ShouldGeneraterandonNumberOnCreateEntity()
        {
            var randonNumber = new RandonNumberEntity();

            Assert.NotEqual(0, randonNumber.Number);
        }
    }
}
