using PoolDinner.Domain.Models;

namespace PoolDinner.Domain.HostAggregate.ValueObjects
{
    public sealed class HostId : ValueObject
    {
        public Guid Value;

        private HostId(Guid value)
        {
            Value = value;
        }

        public static HostId Create(Guid id)
        {
             return new HostId(id);
        }

        public static HostId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}