namespace ProvaPub.Application.UseCases.RandomNumber.Commons
{
    public class RandomNumberResponse(
        Guid randonNumberId,
        int number)
    {
        public Guid RandonNumberId { get; } = randonNumberId;
        public int Number { get; } = number;
    }
}
