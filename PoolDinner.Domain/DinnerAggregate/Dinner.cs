using PoolDinner.Domain.Common;
using PoolDinner.Domain.DinnerAggregate.Entities;
using PoolDinner.Domain.DinnerAggregate.ValueObjects;
using PoolDinner.Domain.HostAggregate.ValueObjects;
using PoolDinner.Domain.MenuAggregate.ValueObjects;
using PoolDinner.Domain.Models;

namespace PoolDinner.Domain.DinnerAggregate
{
    public sealed class Dinner : Entity<DinnerId>
    {
        public string Name { get; init; }

        public string Description { get; init; }

        public DateTime StartDateTime { get; init; }

        public DateTime EndDateTime { get; init; }

        public DateTime StartedDateTime { get; init; }

        public DateTime EndedDateTime { get; init; }

        public string Status { get; init; } // Upcoming, InProgress, Ended, Cancelled

        public bool IsPublic { get; init; }

        public int MaxGuests { get; init; }

        public Price Price { get; init; }

        public HostId HostId { get; init; }

        public MenuId MenuId { get; init; }

        public string ImageUrl { get; init; }

        public Location Location { get; init; }

        private readonly List<Reservation> _reservations = new();

        public IReadOnlyList<Reservation> Reservations ()
        {
            return _reservations.AsReadOnly();
        }

        public DateTime CreatedDateTime { get; init; }

        public DateTime UpdatedDateTime { get; init; }

        private Dinner(DinnerId id,
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            DateTime startedDateTime,
            DateTime endedDateTime,
            string status,
            bool isPublic,
            int maxGuests,
            Price price,
            HostId hostId,
            MenuId menuId,
            string imageUrl,
            Location location,
            DateTime createdTime,
            DateTime updatedTime):base(id)
        {
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Status = status;
            IsPublic = isPublic;
            MaxGuests = maxGuests;
            Price = price;
            HostId = hostId;
            MenuId = menuId;
            ImageUrl = imageUrl;
            Location = location;
            CreatedDateTime = createdTime;
            UpdatedDateTime = updatedTime;
        }

        public static Dinner Create(string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            DateTime startedDateTime,
            DateTime endedDateTime,
            string status,
            bool isPublic,
            int maxGuests,
            Price price,
            HostId hostId,
            MenuId menuId,
            string imageUrl,
            Location location)
        {

            return new(DinnerId.CreateUnique(),
                name,
                description,
                startDateTime,
                endDateTime,
                startedDateTime,
                endedDateTime,
                status,
                isPublic,
                maxGuests,
                price,
                hostId,
                menuId,
                imageUrl,
                location,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

    }
}

