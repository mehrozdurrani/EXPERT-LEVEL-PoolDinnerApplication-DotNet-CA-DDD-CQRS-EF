using PoolDinner.Domain.BillAggregate.ValueObjects;
using PoolDinner.Domain.DinnerAggregate.ValueObjects;
using PoolDinner.Domain.GuestAggregate.ValueObjects;
using PoolDinner.Domain.MenuReviewAggregate;
using PoolDinner.Domain.Models;
using PoolDinner.Domain.UserAggregate.ValueObjects;

namespace PoolDinner.Domain.GuestAggregate
{
    public sealed class Guest : Entity<GuestId>
    {
        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string ProfileImageUrl { get; init; }

        public double Rating { get; init; }

        public UserId UserId { get; init; }

        private readonly List<DinnerId> _upcomingDinnerIds = new();

        private readonly List<DinnerId> _pastDinnerIds = new();

        private readonly List<BillId> _billIds = new();

        private readonly List<MenuReviewId> _menuReviewIds = new();

        public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
        
        public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();

        public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();

        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    
        public DateTime CreatedDateTime;

        public DateTime UpdatedDateTime;

        private Guest(GuestId id,
            string firstName,
            string lastName,
            string profileImageUrl,
            double rating,
            UserId userId,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImageUrl = profileImageUrl;
            Rating = rating;
            UserId = userId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Guest Create(string firstName,
            string lastName,
            string profileImageUrl,
            double rating,
            UserId userId)
        {

            return new(GuestId.CreateUnique(),
                firstName,
                lastName,
                profileImageUrl,
                rating,
                userId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}

