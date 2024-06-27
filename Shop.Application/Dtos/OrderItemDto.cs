namespace Shop.Application.Dtos
{
    public record OrderItemDto(int Id, int Quantity, ProductDto Product, SizeDto Size);
}
