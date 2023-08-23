using PoolDinner.Application.Common.Interfaces.Persistence;
using PoolDinner.Domain.MenuAggregate;

namespace PoolDinner.Infrastructure.Persistence.Repositories
{
    public class MenuRepository: IMenuRepository
    {
        private static readonly List<Menu> _menus = new();

        public void Add(Menu menu)
        {
            _menus.Add(menu);
        }
    }
}

