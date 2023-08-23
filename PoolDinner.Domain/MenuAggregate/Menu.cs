using PoolDinner.Domain.DinnerAggregate.ValueObjects;
using PoolDinner.Domain.MenuReviewAggregate;
using PoolDinner.Domain.HostAggregate.ValueObjects;
using PoolDinner.Domain.Models;
using PoolDinner.Domain.MenuAggregate.ValueObjects;
using PoolDinner.Domain.Common;
using PoolDinner.Domain.MenuAggregate.Entities;

namespace PoolDinner.Domain.MenuAggregate
{
    public class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();

        private readonly List<DinnerId> _dinnerIds = new();

        private readonly List<MenuReviewId> _menuReviewIds = new();

        public HostId HostId { get; init; }

        public string Name { get; init; }

        public string Description { get; init; }

        public AverageRating AverageRating { get; init; }

        public DateTime CreatedDateTime { get; init; }

        public DateTime UpdatedDateTime { get; init; }

        public IReadOnlyList<MenuSection> Sections()
        {
            return _sections.AsReadOnly();
        }

        public IReadOnlyList<DinnerId> DinnerIds()
        {
            return _dinnerIds.AsReadOnly();
        }

        public IReadOnlyList<MenuReviewId> MenuReviewIds()
        {
            return _menuReviewIds.AsReadOnly();
        }

        private Menu(MenuId id,
            HostId hostId,
            string name,
            string description,
            List<MenuSection> sections,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            HostId = hostId;
            Name = name;
            Description = description;
            _sections = sections;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Menu Create(HostId hostId,
            string name,
            string description,
            List<MenuSection> sections)
        {
            return new(MenuId.CreateUnique(),
                hostId,
                name,
                description,
                sections,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}

