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
            config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>().
                Map(dest => dest.HostId, src => src.HostId).
                Map(dest => dest, src => src.Request);

            config.NewConfig<Menu, MenuResponse>().
                Map(dest => dest.Id, src => src.Id.Value).
                Map(dest => dest.AverageRating, src => src.AverageRating.Value).
                Map(dest => dest.HostId, src => src.HostId.Value).
                Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(dinnerId => dinnerId.Value)).
                Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(menuReviewId => menuReviewId.Value)).
                Map(dest=>dest.Sections, src=>src.Sections);

            config.NewConfig<MenuSection, MenuSectionResponse>().
                Map(dest => dest.Id, src => src.Id.Value).
                Map(dest =>dest.Items , src=>src.Items);

            config.NewConfig<MenuItem, MenuItemResponse>().
                Map(dest => dest.Id, src => src.Id.Value);
        }
    }
}

