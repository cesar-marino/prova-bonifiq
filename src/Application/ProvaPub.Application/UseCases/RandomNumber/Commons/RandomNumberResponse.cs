using ProvaPub.Domain.Entities;

namespace ProvaPub.Application.UseCases.RandomNumber.Commons
{
    public class RandomNumberResponse(
        Guid randonNumberId,
        int number)
    {
        public Guid RandonNumberId { get; } = randonNumberId;
        public int Number { get; } = number;

        public static RandomNumberResponse FromEntity(RandomNumberEntity randomNumber) => new(
            randonNumberId: randomNumber.Id,
            number: randomNumber.Number);
    }
}
