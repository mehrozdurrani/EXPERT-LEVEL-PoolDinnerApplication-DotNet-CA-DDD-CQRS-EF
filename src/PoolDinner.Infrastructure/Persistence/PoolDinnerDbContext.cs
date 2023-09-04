using Microsoft.EntityFrameworkCore;

using PoolDinner.Domain.MenuAggregate;

namespace PoolDinner.Infrastructure.Persistence
{
    public class PoolDinnerDbContext : DbContext
    {
        public DbSet<Menu> Menus { get; set; } = null!;

        public PoolDinnerDbContext(DbContextOptions<PoolDinnerDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PoolDinnerDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
