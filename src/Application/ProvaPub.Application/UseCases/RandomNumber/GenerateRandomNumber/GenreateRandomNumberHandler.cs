using ProvaPub.Application.UseCases.RandomNumber.Commons;

namespace ProvaPub.Application.UseCases.RandomNumber.GenerateRandomNumber
{
    public class GenreateRandomNumberHandler : IGenerateRandomNumberHandler
    {
        public Task<RandonNumberResponse> Handle(GenerateRandomNumberRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
