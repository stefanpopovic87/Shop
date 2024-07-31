using Shop.Application.Dtos;

namespace Shop.Application.Order.Get
{
    public record GetOrderItemsResponse(int Id, int Quantity, ProductDto Product, SizeDto Size);
}
