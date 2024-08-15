namespace Shop.Application.Orders.Get
{
    public record GetOrderResponse(int Id, int? AddressId, List<GetOrderItemsResponse> OrderItems);
}
