using Microsoft.EntityFrameworkCore;

using PoolDinner.Application.Common.Interfaces.Persistence;
using PoolDinner.Domain.MenuAggregate;

namespace PoolDinner.Infrastructure.Persistence.Repositories
{
    public class MenuRepository: IMenuRepository
    {
        private readonly DbContext _dbContext;

        private readonly List<Menu> _menus = new();
        public MenuRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Menu menu)
        {
            _dbContext.Add(menu);
            _dbContext.SaveChanges();
        }
    }
}

