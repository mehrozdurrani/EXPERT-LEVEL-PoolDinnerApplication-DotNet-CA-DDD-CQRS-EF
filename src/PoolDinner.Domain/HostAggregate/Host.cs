using PoolDinner.Domain.Common;
using PoolDinner.Domain.DinnerAggregate.ValueObjects;
using PoolDinner.Domain.HostAggregate.ValueObjects;
using PoolDinner.Domain.MenuAggregate.ValueObjects;
using PoolDinner.Domain.Models;
using PoolDinner.Domain.UserAggregate.ValueObjects;

namespace PoolDinner.Domain.HostAggregate
{
    public sealed class Host: Entity<HostId>
    {
        private readonly List<MenuId> _menuIds = new();

        private readonly List<DinnerId> _dinnerIds = new();

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string ProfileImage { get; init; }

        public AverageRating AverageRating { get; init; }

        public UserId UserId { get; init; }

        public DateTime CreatedDateTime;

        public DateTime UpdatedDateTime;

        public IReadOnlyList<MenuId> MenuIds()
        {
            return _menuIds.AsReadOnly();
        }

        public IReadOnlyList<DinnerId> DinnerIds()
        {
            return _dinnerIds.AsReadOnly();
        }

        public Host(HostId hostId,
            string firstName,
            string lastName,
            string profileImage,
            AverageRating averageRating,
            UserId userId): base(hostId)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            AverageRating = averageRating;
            UserId = userId;
        }

        public static Host Create(string firstName,
            string lastName,
            string profileImage,
            AverageRating averageRating,
            UserId userId)
        {
            return new(HostId.CreateUnique(),
                firstName,
                lastName,
                profileImage,
                averageRating,
                userId);

        }
    }
}

