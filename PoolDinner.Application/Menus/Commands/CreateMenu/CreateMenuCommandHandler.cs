using PoolDinner.Application.Common.Interfaces.Persistence;
using PoolDinner.Domain.HostAggregate.ValueObjects;
using PoolDinner.Domain.MenuAggregate;
using PoolDinner.Domain.MenuAggregate.Entities;
using MediatR;

namespace PoolDinner.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, Menu>
    {
        private readonly IMenuRepository _menuRepository;

        public CreateMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<Menu> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask; // temporary to remove warning

            // Create Menu
            var menu = Menu.Create(
                HostId.Create(Guid.Parse(request.HostId)),
                request.Name,
                request.Description,
                request.Sections.Select(
                    section => MenuSection.Create(
                        section.Name,
                    section.Description,
                    section.Items.Select(
                        items => MenuItem.Create(items.Name, items.Description)).ToList())).ToList());

            // Persist Menu
            _menuRepository.Add(menu);

            // Return Menu
            return menu; 
        }
    }
}

