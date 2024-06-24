namespace Shop.Application.Dtos
{
    public record ProductDto(int id, string Name, string Description, decimal Price, string? PictureUrl);
}
