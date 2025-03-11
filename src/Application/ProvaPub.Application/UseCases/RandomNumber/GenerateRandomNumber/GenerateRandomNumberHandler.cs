using ProvaPub.Application.UseCases.RandomNumber.Commons;
using ProvaPub.Domain.Entities;
using ProvaPub.Domain.Repositories;

namespace ProvaPub.Application.UseCases.RandomNumber.GenerateRandomNumber
{
    public class GenerateRandomNumberHandler(IRandomNumberRepository randomNumberRepository) : IGenerateRandomNumberHandler
    {
        public async Task<RandomNumberResponse> Handle(GenerateRandomNumberRequest request, CancellationToken cancellationToken)
        {
            var randomNumber = new RandomNumberEntity();
            await randomNumberRepository.CheckNumberAsync(randomNumber.Number, cancellationToken);

            throw new NotImplementedException();
        }
    }
}
