using MediatR;
using ProvaPub.Application.UseCases.RandonNumber.Commons;

namespace ProvaPub.Application.UseCases.RandonNumber.GenerateRandonNumber
{
    public interface IGenerateRandonNumberHandler : IRequestHandler<GenerateRandonNumberRequest, RandonNumberResponse>
    {
    }
}
