using ProvaPub.Domain.Entities;

namespace ProvaPub.Infrastructure.Data.Models
{
    public class RandomNumberModel
    {
        public Guid RandomNumberId { get; }
        public int Number { get; }

        public RandomNumberModel(
            Guid randomNumberId,
            int number)
        {
            RandomNumberId = randomNumberId;
            Number = number;
        }

        public static RandomNumberModel FromEntity(RandomNumberEntity randomNumber) => new(
            randomNumberId: randomNumber.Id,
            number: randomNumber.Number);

        public RandomNumberEntity ToEntity() => new(
            randomNumberId: RandomNumberId,
            number: Number);
    }
}
