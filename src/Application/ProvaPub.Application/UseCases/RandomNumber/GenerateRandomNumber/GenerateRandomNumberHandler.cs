using ProvaPub.Application.UseCases.RandomNumber.Commons;
using ProvaPub.Domain.Entities;
using ProvaPub.Domain.Repositories;
using ProvaPub.Domain.SeedWork;

namespace ProvaPub.Application.UseCases.RandomNumber.GenerateRandomNumber
{
    public class GenerateRandomNumberHandler(
        IRandomNumberRepository randomNumberRepository,
        IUnitOfWork unitOfWork) : IGenerateRandomNumberHandler
    {
        public async Task<RandomNumberResponse> Handle(GenerateRandomNumberRequest request, CancellationToken cancellationToken)
        {
            var randomNumber = new RandomNumberEntity();
            var existNumber = await randomNumberRepository.CheckNumberAsync(randomNumber.Number, cancellationToken);

            while (existNumber)
            {
                randomNumber.GenerateNumber();
                existNumber = await randomNumberRepository.CheckNumberAsync(randomNumber.Number, cancellationToken);
            }

            await randomNumberRepository.InsertAsync(randomNumber!, cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);
            return RandomNumberResponse.FromEntity(randomNumber);
        }
    }
}
