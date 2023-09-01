namespace PoolDinner.Contracts.Menus
{
    public record CreateMenuRequest(
        string Name,
        string Description,
        List<MenuSectionRequest> Sections);

    public record MenuSectionRequest(
        string Name,
        string Description,
        List<MenuItemsRequest> Items);

    public record MenuItemsRequest(
        string Name,
        string Description);
}

