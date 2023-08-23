using PoolDinner.Domain.MenuAggregate.ValueObjects;
using PoolDinner.Domain.Models;

namespace PoolDinner.Domain.MenuAggregate.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();

        public string Name { get; init; }

        public string Description { get; init; }

        public IReadOnlyList<MenuItem> Items()
        {
            return _items.AsReadOnly();
        }

        private MenuSection(
            MenuSectionId id,
            string name,
            string description,
            List<MenuItem> items) : base(id)
        {
            Name = name;
            Description = description;
            _items = items;
        }
        public static MenuSection Create(
            string name,
            string description,
            List<MenuItem> items)
        {
            return new(
                MenuSectionId.CreateUnique(),
                name,
                description,
                items);
        }
    }
}