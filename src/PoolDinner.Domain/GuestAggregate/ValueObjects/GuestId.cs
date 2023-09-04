using PoolDinner.Domain.Models;

namespace PoolDinner.Domain.GuestAggregate.ValueObjects
{
    public sealed class GuestId : ValueObject
    {
        public Guid Value;

        private GuestId(Guid value)
        {
            Value = value;
        }

        public static GuestId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
