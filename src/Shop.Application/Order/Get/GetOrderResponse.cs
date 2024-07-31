namespace Shop.Application.Order.Get
{
    public record GetOrderResponse(int Id, int? AddressId, List<GetOrderItemsResponse> OrderItems);
}
