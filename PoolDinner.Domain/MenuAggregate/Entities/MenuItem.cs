using PoolDinner.Domain.MenuAggregate.ValueObjects;
using PoolDinner.Domain.Models;

namespace PoolDinner.Domain.MenuAggregate.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        public string Name { get; init; }

        public string Description { get; init; }

        private MenuItem(MenuItemId id, string name, string description) : base(id)
        {
            Name = name;
            Description = description;
        }

        public static MenuItem Create(string name, string description)
        {
            return new(MenuItemId.CreateUnique(), name, description);
        }
    }
}