using PoolDinner.Domain.Models;

namespace PoolDinner.Domain.MenuReviewAggregate
{
    public sealed class MenuReviewId : ValueObject
    {
        public Guid Value;

        private MenuReviewId(Guid _value)
        {
            Value = _value;
        }

        public static MenuReviewId CreateUnique()
        {
            return (new(Guid.NewGuid()));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}