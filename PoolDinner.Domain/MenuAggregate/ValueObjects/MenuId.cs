using PoolDinner.Domain.Models;

namespace PoolDinner.Domain.MenuAggregate.ValueObjects
{
    public sealed class MenuId : ValueObject
    {
        public Guid Value { get; init; }

        private MenuId(Guid value)
        {
            Value = value;
        }

        public static MenuId Create(Guid value)
        {
            return new MenuId(value);
        }

        public static MenuId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}