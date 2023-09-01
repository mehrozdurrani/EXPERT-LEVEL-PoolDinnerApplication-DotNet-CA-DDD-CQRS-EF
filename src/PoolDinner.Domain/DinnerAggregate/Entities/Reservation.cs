using PoolDinner.Domain.BillAggregate.ValueObjects;
using PoolDinner.Domain.DinnerAggregate.ValueObjects;
using PoolDinner.Domain.GuestAggregate.ValueObjects;
using PoolDinner.Domain.Models;

namespace PoolDinner.Domain.DinnerAggregate.Entities
{
    public sealed class Reservation : Entity<ReservationId>
    {
        public int GuestCount { get; init; }

        public string Status { get; init; } // PendingGuestConfirmation, Reserved, Cancelled

        public GuestRatingId GuestId { get; init; }

        public BillId BillId { get; init; }

        public DateTime ArrivalDateTime { get; init; }

        public DateTime CreatedDateTime { get; init; }

        public DateTime UpdatedDateTime { get; init; }

        private Reservation(ReservationId id,
            int guestCount,
            string status,
            GuestRatingId guestId,
            BillId billId,
            DateTime arrivalDateTime,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            GuestCount = guestCount;
            Status = status;
            GuestId = guestId;
            BillId = billId;
            ArrivalDateTime = arrivalDateTime;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Reservation Create(int guestCount,
            string status,
            GuestRatingId guestId,
            BillId billId,
            DateTime arrivalDateTime)
        {
            return new(
                ReservationId.CreateUnique(),
                guestCount,
                status,
                guestId,
                billId,
                arrivalDateTime,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}

