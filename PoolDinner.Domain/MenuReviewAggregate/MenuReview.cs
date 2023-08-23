using PoolDinner.Domain.DinnerAggregate.ValueObjects;
using PoolDinner.Domain.GuestAggregate.ValueObjects;
using PoolDinner.Domain.HostAggregate.ValueObjects;
using PoolDinner.Domain.MenuAggregate.ValueObjects;
using PoolDinner.Domain.Models;

namespace PoolDinner.Domain.MenuReviewAggregate
{
    public sealed class MenuReview : AggregateRoot<MenuReviewId>
    {
        public float Rating;

        public string Comment;

        public HostId HostId{ get; init; }

        public MenuId MenuId { get; init; }

        public GuestRatingId GuestId { get; init; }

        public DinnerId DinnerId { get; init; }

        public DateTime CreatedDateTime { get; init; }

        public DateTime UpdatedDateTime { get; init; }

        private MenuReview(MenuReviewId menuReviewId,
            float rating,
            string comment,
            HostId hostId,
            MenuId menuId,
            GuestRatingId guestId,
            DinnerId dinnerId,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(menuReviewId)
        {
            Rating = rating;
            Comment = comment;
            HostId = hostId;
            MenuId = menuId;
            GuestId = guestId;
            DinnerId = dinnerId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }
        public static MenuReview Create(float rating,
            string comment,
            HostId hostId,
            MenuId menuId,
            GuestRatingId guestId,
            DinnerId dinnerId)
        {
            return new (MenuReviewId.CreateUnique(),
                rating,
                comment,
                hostId,
                menuId,
                guestId,
                dinnerId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

    }
}

