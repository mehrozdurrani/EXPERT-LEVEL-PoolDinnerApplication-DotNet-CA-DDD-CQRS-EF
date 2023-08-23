using PoolDinner.Domain.Models;

namespace PoolDinner.Domain.Common
{
    public sealed class Rating : ValueObject
    {
        public double Value;

        private Rating(double value)
        {
            Value = value;
        }

        public static Rating CreateNew(double rating)
        {
            // TODO Check if the rating in right format
            return new(rating);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}