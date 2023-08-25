
using Microsoft.EntityFrameworkCore;

using PoolDinner.Domain.MenuAggregate;

namespace PoolDinner.Infrastructure.Persistence
{
    public class PoolDinnerDbContext : DbContext
    {
        public PoolDinnerDbContext(DbContextOptions <PoolDinnerDbContext> options): base(options)
        {

        }
        public DbSet<Menu> Menus { get; set; } = null!;
    }
}

