using PoolDinner.Application.Menus.Commands.CreateMenu;
using PoolDinner.Contracts.Menus;
using PoolDinner.Domain.MenuAggregate;
using PoolDinner.Domain.MenuAggregate.Entities;
using Mapster;

namespace PoolDinner.Api.Mapping
{
    public class MenuMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config
                .NewConfig<(CreateMenuRequest Request, Guid HostId), CreateMenuCommand>()
                .Map(dest => dest.HostId, src => src.HostId)
                .Map(dest => dest, src => src.Request);

            config
                .NewConfig<Menu, MenuResponse>()
                .Map(dest => dest.Id, src => src.Id.Value.ToString())
                .Map(dest => dest.AverageRating, src => src.AverageRating.Value)
                .Map(dest => dest.HostId, src => src.HostId.Value.ToString())
                .Map(
                    dest => dest.DinnerIds,
                    src => src.DinnerIds.Select(dinnerId => dinnerId.Value.ToString())
                )
                .Map(
                    dest => dest.MenuReviewIds,
                    src => src.MenuReviewIds.Select(menuReviewId => menuReviewId.Value.ToString())
                )
                .Map(dest => dest.Sections, src => src.Sections);

            config
                .NewConfig<MenuSection, MenuSectionResponse>()
                .Map(dest => dest.Id, src => src.Id.Value.ToString())
                .Map(dest => dest.Items, src => src.Items);

            config
                .NewConfig<MenuItem, MenuItemResponse>()
                .Map(dest => dest.Id, src => src.Id.Value.ToString());
        }
    }
}
