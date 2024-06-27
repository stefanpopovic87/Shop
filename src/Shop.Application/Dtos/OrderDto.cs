namespace Shop.Application.Dtos
{
    public record OrderDto(int Id, int? AddressId, List<OrderItemDto> OrderItems);
}
