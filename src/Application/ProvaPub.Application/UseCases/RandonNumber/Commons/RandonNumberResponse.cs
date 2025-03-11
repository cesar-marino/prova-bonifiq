namespace ProvaPub.Application.UseCases.RandonNumber.Commons
{
    public class RandonNumberResponse(
        Guid randonNumberId,
        int number)
    {
        public Guid RandonNumberId { get; } = randonNumberId;
        public int Number { get; } = number;
    }
}
