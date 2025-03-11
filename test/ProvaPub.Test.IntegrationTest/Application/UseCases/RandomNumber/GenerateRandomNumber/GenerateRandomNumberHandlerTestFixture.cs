using ProvaPub.Application.UseCases.RandomNumber.GenerateRandomNumber;
using ProvaPub.Test.IntegrationTest.Commons;

namespace ProvaPub.Test.IntegrationTest.Application.UseCases.RandomNumber.GenerateRandomNumber
{
    public class GenerateRandomNumberHandlerTestFixture : FixtureBase
    {
        public GenerateRandomNumberRequest MakeGenerateRandomNumberRequest() => new();
    }
}
