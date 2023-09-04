using PoolDinner.Domain.DinnerAggregate.ValueObjects;
using PoolDinner.Domain.GuestAggregate.ValueObjects;
using PoolDinner.Domain.HostAggregate.ValueObjects;
using PoolDinner.Domain.Models;

namespace PoolDinner.Domain.GuestAggregate.Entities
{
    public sealed class GuestRating : Entity<GuestRatingId>
    {
        public HostId HostId { get; init; }
        public DinnerId DinnerId { get; init; }
        public double Rating { get; init; }
        public DateTime CreatedDateTime { get; init; }
        public DateTime UpdatedDateTime { get; init; }

        private GuestRating(
            GuestRatingId id,
            HostId hostId,
            DinnerId dinnerId,
            double rating,
            DateTime createdDateTime,
            DateTime updatedDateTime
        )
            : base(id)
        {
            HostId = hostId;
            DinnerId = dinnerId;
            Rating = rating;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static GuestRating Create(HostId hostId, DinnerId dinnerId, double rating)
        {
            return new(
                GuestRatingId.CreateUnique(),
                hostId,
                dinnerId,
                rating,
                DateTime.UtcNow,
                DateTime.UtcNow
            );
        }
    }
}
