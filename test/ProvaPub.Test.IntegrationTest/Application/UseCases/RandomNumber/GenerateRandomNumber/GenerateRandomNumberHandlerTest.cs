using ProvaPub.Application.UseCases.RandomNumber.GenerateRandomNumber;
using ProvaPub.Infrastructure.Data.Contexts;
using ProvaPub.Infrastructure.Data.Repositories;

namespace ProvaPub.Test.IntegrationTest.Application.UseCases.RandomNumber.GenerateRandomNumber
{
    public class GenerateRandomNumberHandlerTest(GenerateRandomNumberHandlerTestFixture fixture) : IClassFixture<GenerateRandomNumberHandlerTestFixture>
    {
        private readonly GenerateRandomNumberHandlerTestFixture _fixture = fixture;

        [Fact(DisplayName = nameof(ShouldReturnTheCorrectResponseIfRandomNumberIsSuccessfullyGenerated))]
        [Trait("Integration/UseCases", "RandomNumber - GenerateRandomNumber")]
        public async Task ShouldReturnTheCorrectResponseIfRandomNumberIsSuccessfullyGenerated()
        {
            var context = _fixture.MakeContext();
            var unitOfWork = new UnitOfWork(context);
            var repository = new RandomNumberRepository(context);

            var sut = new GenerateRandomNumberHandler(
                randomNumberRepository: repository, 
                unitOfWork: unitOfWork);

            var request = _fixture.MakeGenerateRandomNumberRequest();
            var response = await sut.Handle(request, _fixture.CancellationToken);

            Assert.NotEqual(0, response.Number);
        }
    }
}
