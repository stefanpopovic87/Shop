namespace Shop.Application.Dtos
{
    public record ProductSizeDto(
        int ProductId, 
        string Name, 
        string Description, 
        decimal Price, 
        string? PictureUrl, 
        string SizeName, 
        int SizeId, 
        int QuantityInStock);
}
