using PoolDinner.Domain.Models;

namespace PoolDinner.Domain.GuestAggregate.ValueObjects
{
    public sealed class GuestRatingId : ValueObject
    {
        public Guid Value;

        private GuestRatingId(Guid value)
        {
            Value = value;
        }

        public static GuestRatingId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}