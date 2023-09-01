namespace PoolDinner.Domain.Models
{
    public abstract class AggregateRootId<TIdType> : ValueObject
    {
        public abstract TIdType Value { get; protected set; }
    }
}

