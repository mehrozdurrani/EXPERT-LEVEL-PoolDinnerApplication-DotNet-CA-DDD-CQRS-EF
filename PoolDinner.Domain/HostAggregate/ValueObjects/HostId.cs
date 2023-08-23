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

        public static HostId Create(string id)
        {
            Guid.TryParse(id, out Guid guid);
            return new HostId(guid);
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