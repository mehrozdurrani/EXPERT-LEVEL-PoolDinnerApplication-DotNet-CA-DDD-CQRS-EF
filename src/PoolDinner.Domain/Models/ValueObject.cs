﻿namespace PoolDinner.Domain.Models
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public bool Equals(ValueObject? other)
        {
            return Equals((object?)other);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;

            return this.GetEqualityComponents().
                SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        { 
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }


        public static bool operator == (ValueObject left, ValueObject right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !left.Equals(right);
        }
    }

}

