namespace Shop.Application.Dtos
{
    public record ProductDto(int Id, string Name, string Description, decimal Price, string Code, int BrandId, int SubcategoryId, int FenderId, List<SizeQuantityDto> SizeQuantities);
}
