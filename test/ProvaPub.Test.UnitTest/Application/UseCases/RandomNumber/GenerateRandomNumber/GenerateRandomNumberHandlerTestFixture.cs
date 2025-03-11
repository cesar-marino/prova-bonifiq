using ProvaPub.Application.UseCases.RandomNumber.GenerateRandomNumber;
using ProvaPub.Test.UnitTest.Commons;

namespace ProvaPub.Test.UnitTest.Application.UseCases.RandomNumber.GenerateRandomNumber
{
    public class GenerateRandomNumberHandlerTestFixture : FixtureBase
    {
        public GenerateRandomNumberRequest MakeGenerateRandomNumberRequest() => new();
    }
}
