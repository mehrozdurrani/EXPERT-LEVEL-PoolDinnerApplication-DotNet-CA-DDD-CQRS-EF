using PoolDinner.Domain.Models;

namespace PoolDinner.Domain.MenuReviewAggregate
{
    public sealed class MenuReviewId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

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
#pragma warning disable CS8618
        private MenuReviewId()
        {
        }
#pragma warning restore CS8618
    }
}