namespace PoolDinner.Contracts.Menus
{
    public record MenuResponse(
        string Id,
        string Name,
        string Description,
        string HostId,
        float AverageRating,
        List<MenuSectionResponse> Sections,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime,
        List<string> DinnerIds,
        List<string> MenuReviewIds);
    
    public record MenuSectionResponse(
        string Id,
        string Name,
        string Description,
        List<MenuItemResponse> Items);

    public record MenuItemResponse(
        string Id,
        string Name,
        string Description);
    
}

