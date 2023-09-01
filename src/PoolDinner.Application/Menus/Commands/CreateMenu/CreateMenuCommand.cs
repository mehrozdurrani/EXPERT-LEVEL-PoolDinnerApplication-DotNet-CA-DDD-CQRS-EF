using PoolDinner.Domain.MenuAggregate;
using MediatR;

namespace PoolDinner.Application.Menus.Commands.CreateMenu
{
    public record CreateMenuCommand(
        Guid HostId,
        string Name,
        string Description,
        List<CreateMenuSectionCommand> Sections) : IRequest<Menu>;

    public record CreateMenuSectionCommand(
        string Name,
        string Description,
        List<CreateMenuItemsCommand> Items);

    public record CreateMenuItemsCommand(
        string Name,
        string Description);
}

