using PoolDinner.Domain.Models;

namespace PoolDinner.Domain.DinnerAggregate.ValueObjects
{
    public sealed class Location : ValueObject
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }

        public Location(string name,
            string address,
            string latitude,
            string longitude)
        {
            Name = name;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Address;
            yield return Latitude;
            yield return Longitude;
        }
    }
}

