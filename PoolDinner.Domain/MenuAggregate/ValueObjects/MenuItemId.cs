using PoolDinner.Domain.Models;

namespace PoolDinner.Domain.MenuAggregate.ValueObjects
{
    public sealed class MenuItemId : ValueObject
    {
        public Guid Value { get; init; }

        private MenuItemId(Guid value)
        {
            Value = value;
        }

        public static MenuItemId Create(Guid id)
        {
            return new(id);
        }

        public static MenuItemId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}