using PoolDinner.Domain.BillAggregate.ValueObjects;
using PoolDinner.Domain.Common;
using PoolDinner.Domain.DinnerAggregate.ValueObjects;
using PoolDinner.Domain.GuestAggregate.ValueObjects;
using PoolDinner.Domain.HostAggregate.ValueObjects;
using PoolDinner.Domain.Models;

namespace PoolDinner.Domain.BillAggregate
{
    public sealed class Bill : Entity<BillId>
    {
        public DinnerId DinnerId { get; init; }

        public GuestRatingId GuestId { get; init; }

        public HostId HostId { get; init; }

        public Price Price { get; init; }

        public DateTime CreatedDateTime { get; init; }

        public DateTime UpdatedDateTime { get; init; }

        public Bill(BillId billId,
            DinnerId dinnerId,
            GuestRatingId guestId,
            HostId hostId,
            Price price,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(billId)
        {
            DinnerId = dinnerId;
            GuestId = guestId;
            HostId = hostId;
            Price = price;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public Bill Create(DinnerId dinnerId,
            GuestRatingId guestId,
            HostId hostId,
            Price price)
        {
            return new(BillId.CreateUnique(),
                dinnerId,
                guestId,
                hostId,
                price,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}

