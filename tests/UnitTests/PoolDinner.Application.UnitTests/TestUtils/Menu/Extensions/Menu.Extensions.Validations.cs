using PoolDinner.Application.Menus.Commands.CreateMenu;
using PoolDinner.Domain.MenuAggregate;
using FluentAssertions;
using PoolDinner.Domain.MenuAggregate.Entities;

namespace PoolDinner.Application.UnitTests.TestUtils.Menus.Extensions
{
    public static partial class MenuExtensions
    {
        public static void ValidateCreatedFrom(this Menu menu, CreateMenuCommand createMenuCommand)
        {
            menu.Name.Should().Be(createMenuCommand.Name);
            menu.Description.Should().Be(createMenuCommand.Description);
            menu.Sections.Should().HaveSameCount(createMenuCommand.Sections);
            menu.Sections.Zip(createMenuCommand.Sections).ToList().ForEach(pair => ValidateSections(pair.First, pair.Second));
        }
        private static void ValidateSections(MenuSection menuSection, CreateMenuSectionCommand createMenuSectionCommand)
        {
            menuSection.Id.Should().NotBeNull();
            menuSection.Name.Should().Be(createMenuSectionCommand.Name);
            menuSection.Description.Should().Be(createMenuSectionCommand.Description);
            menuSection.Items.Should().HaveSameCount(createMenuSectionCommand.Items);
            menuSection.Items.Zip(createMenuSectionCommand.Items).ToList().ForEach(pair => ValidateItems(pair.First, pair.Second));
        }
        private static void ValidateItems(MenuItem menuItem, CreateMenuItemsCommand createMenuItemsCommand)
        {
            menuItem.Id.Should().NotBeNull();
            menuItem.Name.Should().Be(createMenuItemsCommand.Name);
            menuItem.Description.Should().Be(createMenuItemsCommand.Description);
        }
    }
}