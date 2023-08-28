using PoolDinner.Domain.Models;

namespace PoolDinner.Domain.MenuAggregate.ValueObjects
{
    public class MenuSectionId : ValueObject
    {
        public Guid Value { get; init; }

        private MenuSectionId(Guid value)
        {
            Value = value;
        }

        public static MenuSectionId Create(Guid id)
        {
            return new(id);
        }

        public static MenuSectionId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
           
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}