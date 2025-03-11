namespace ProvaPub.Application.UseCases.RandomNumber.Commons
{
    public class RandonNumberResponse(
        Guid randonNumberId,
        int number)
    {
        public Guid RandonNumberId { get; } = randonNumberId;
        public int Number { get; } = number;
    }
}
