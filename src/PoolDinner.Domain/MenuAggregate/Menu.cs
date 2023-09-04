using PoolDinner.Domain.DinnerAggregate.ValueObjects;
using PoolDinner.Domain.MenuReviewAggregate;
using PoolDinner.Domain.HostAggregate.ValueObjects;
using PoolDinner.Domain.Models;
using PoolDinner.Domain.MenuAggregate.ValueObjects;
using PoolDinner.Domain.Common;
using PoolDinner.Domain.MenuAggregate.Entities;

namespace PoolDinner.Domain.MenuAggregate
{
    public class Menu : AggregateRoot<MenuId, Guid>
    {
        private readonly List<MenuSection> _sections = new();

        private readonly List<DinnerId> _dinnerIds = new();

        private readonly List<MenuReviewId> _menuReviewIds = new();

        public HostId HostId { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public AverageRating AverageRating { get; private set; }

        public DateTime CreatedDateTime { get; private set; }

        public DateTime UpdatedDateTime { get; private set; }

        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

        private Menu(
            MenuId id,
            HostId hostId,
            string name,
            string description,
            AverageRating averageRating,
            List<MenuSection> sections,
            DateTime createdDateTime,
            DateTime updatedDateTime
        )
            : base(id)
        {
            HostId = hostId;
            Name = name;
            Description = description;
            AverageRating = averageRating;
            _sections = sections;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Menu Create(
            HostId hostId,
            string name,
            string description,
            List<MenuSection> sections
        )
        {
            return new(
                MenuId.CreateUnique(),
                hostId,
                name,
                description,
                AverageRating.CreateNew(),
                sections,
                DateTime.UtcNow,
                DateTime.UtcNow
            );
        }

#pragma warning disable CS8618
        private Menu() { }
#pragma warning restore CS8618
    }
}
