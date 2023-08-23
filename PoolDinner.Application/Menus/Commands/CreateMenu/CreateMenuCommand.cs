using PoolDinner.Domain.MenuAggregate;
using MediatR;

namespace PoolDinner.Application.Menus.Commands.CreateMenu
{
    public record CreateMenuCommand(
        string HostId,
        string Name,
        string Description,
        List<MenuSectionCommand> Sections): IRequest<Menu>;

    public record MenuSectionCommand(
        string Name,
        string Description,
        List<MenuItemsCommand> Items);

    public record MenuItemsCommand(
        string Name,
        string Description);
}

