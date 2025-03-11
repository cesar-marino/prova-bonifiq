using MediatR;
using ProvaPub.Application.UseCases.RandonNumber.Commons;

namespace ProvaPub.Application.UseCases.RandonNumber.GenerateRandonNumber
{
    public class GenerateRandonNumberRequest : IRequest<RandonNumberResponse>
    {
    }
}
