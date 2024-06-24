using Shop.Domain.Entities.Base;
using Shop.Domain.Entities.Enums;

namespace Shop.Domain.Entities.Order;

public class Order : BaseEntity
{
    public int Id { get; private set; }
    public int BuyerId { get; private set; }
    public int StatusId { get; private set; }
    public int ShippingAddressId { get; private set; }
    public OrderStatus Status { get; private set; } = new OrderStatus((int)OrderStatusEnum.Pending, OrderStatusEnum.Pending.ToString());
    public Address ShippingAddress { get; private set; } = new();
    public List<OrderItem> Items { get; private set; } = [];
}
