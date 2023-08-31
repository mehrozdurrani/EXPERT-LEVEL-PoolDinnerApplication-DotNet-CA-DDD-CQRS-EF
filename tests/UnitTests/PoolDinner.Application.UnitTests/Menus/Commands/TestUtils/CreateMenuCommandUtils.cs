using PoolDinner.Application.Menus.Commands.CreateMenu;
using PoolDinner.Application.UnitTests.TestUtils.Constants;

namespace PoolDinner.Application.UnitTests.Menus.Commands.TestUtils
{
    public static class CreateMenuCommandUtils
    {
        public static CreateMenuCommand CreateCommand(List<CreateMenuSectionCommand>? sections = null) =>
        new CreateMenuCommand(
            Constants.Host.Id.Value,
            Constants.MenuConstants.Name,
            Constants.MenuConstants.Description,
            sections ?? CreateSectionsCommand(2)
        );
        public static List<CreateMenuSectionCommand> CreateSectionsCommand(int sectionCount = 1,
        List<CreateMenuItemsCommand>? items = null)
        => Enumerable.Range(0, sectionCount).Select(index => new CreateMenuSectionCommand(
            Name: $"Menu Section Name {index}",
            Description: $"Menu Section Description {index}",
            Items: items ?? CreateItemsCommand(1)
        )).ToList();
        public static List<CreateMenuItemsCommand> CreateItemsCommand(int itemCount)
        => Enumerable.Range(0, itemCount).Select(index => new CreateMenuItemsCommand(
            Name: $"Menu Item Name {index}",
            Description: $"Menu Item Description{index}"
        )).ToList();
    }
}