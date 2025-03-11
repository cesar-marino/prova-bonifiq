using MediatR;
using ProvaPub.Application.UseCases.RandomNumber.Commons;

namespace ProvaPub.Application.UseCases.RandomNumber.GenerateRandomNumber
{
    public interface IGenerateRandomNumberHandler : IRequestHandler<GenerateRandomNumberRequest, RandomNumberResponse>
    {
    }
}
