using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoolDinner.Domain.HostAggregate.ValueObjects;
using PoolDinner.Domain.MenuAggregate;
using PoolDinner.Domain.MenuAggregate.Entities;
using PoolDinner.Domain.MenuAggregate.ValueObjects;

namespace PoolDinner.Infrastructure.Persistence.Configurations
{
    public class MenuConfigurations : IEntityTypeConfiguration<Menu>
    {
        public MenuConfigurations()
        {
        }

        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            ConfigureMenuTable(builder);
            ConfigureMenuSectionsTable(builder);
            ConfigureMenuDinnerIdsTable(builder);
            ConfigureMenuMenuReviewIdsTable(builder);
        }

        private void ConfigureMenuMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.MenuReviewIds, mri =>
            {
                mri.ToTable("MenuMenuReviewIds");
                mri.WithOwner().HasForeignKey("MenuId");
                mri.HasKey("Id");
                mri.Property(id => id.Value).
                HasColumnName("ReviewId").
                ValueGeneratedNever();
            });
            builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!.
                SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.DinnerIds, dib =>
            {
                dib.ToTable("MenuDinnerIds");
                dib.WithOwner().HasForeignKey("MenuId");
                dib.HasKey("Id");
                dib.Property(id => id.Value).
                HasColumnName("DinnerId").
                ValueGeneratedNever();
            });
            builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!.
                SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.Sections, sb =>
            {
                sb.ToTable("MenuSections");
                sb.WithOwner().HasForeignKey("MenuId");
                sb.HasKey("Id", "MenuId");
                sb.Property(s => s.Id).
                HasColumnName("MenuSectionId").
                ValueGeneratedNever().
                HasConversion(id => id.Value,
                value => MenuSectionId.Create(value));
                sb.Property(s => s.Name).HasMaxLength(100);
                sb.Property(s => s.Description).HasMaxLength(100);
                sb.OwnsMany(s => s.Items, ib =>
                {
                    ib.ToTable("MenuItems");
                    ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");
                    ib.HasKey(nameof(MenuItem.Id), "MenuId", "MenuSectionId");
                    ib.Property(i => i.Id).
                    ValueGeneratedNever().
                    HasConversion(
                        id => id.Value,
                    value => MenuItemId.Create(value));
                    ib.Property(i => i.Name).HasMaxLength(100);
                    ib.Property(i => i.Description).HasMaxLength(100);

                });
            });
        }

        private void ConfigureMenuTable(EntityTypeBuilder<Menu> builder)
        {
            //Create Table
            builder.ToTable("Menu");

            // Table Configuration
            builder.HasKey(m => m.Id);

            // Property Configuration of Strong ID
            builder.Property(m => m.Id).
                ValueGeneratedNever().
                HasConversion(
                id => id.Value,
                value => MenuId.Create(value));
            builder.Property(m => m.Name).HasMaxLength(100);
            builder.Property(m => m.Description).HasMaxLength(200);
            builder.OwnsOne(m => m.AverageRating);
            builder.Property(m => m.HostId).HasConversion(
                id => id.Value,
                value => HostId.Create(value));
        }
    }
}    

