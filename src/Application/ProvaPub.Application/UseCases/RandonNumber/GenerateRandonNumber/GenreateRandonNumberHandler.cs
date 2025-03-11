using ProvaPub.Application.UseCases.RandonNumber.Commons;

namespace ProvaPub.Application.UseCases.RandonNumber.GenerateRandonNumber
{
    public class GenreateRandonNumberHandler : IGenerateRandonNumberHandler
    {
        public Task<RandonNumberResponse> Handle(GenerateRandonNumberRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
