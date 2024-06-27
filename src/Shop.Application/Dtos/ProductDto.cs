namespace Shop.Application.Dtos
{
    public record ProductDto(int Id, string Name, string Description, decimal Price, string? PictureUrl);
}
