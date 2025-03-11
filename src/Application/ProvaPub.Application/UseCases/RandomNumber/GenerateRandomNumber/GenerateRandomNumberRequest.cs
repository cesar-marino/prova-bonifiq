using MediatR;
using ProvaPub.Application.UseCases.RandomNumber.Commons;

namespace ProvaPub.Application.UseCases.RandomNumber.GenerateRandomNumber
{
    public class GenerateRandomNumberRequest : IRequest<RandomNumberResponse>
    {
    }
}
