using Shop.Domain.Entities.Enums;

namespace Shop.Domain.Entities.Orders;

public class Order
{
    public int Id { get; private set; }
    public int BuyerId { get; private set; }
    public int StatusId { get; private set; }
    public int? ShippingAddressId { get; private set; } // TODO change to not null after create address logic
    public OrderStatus Status { get; private set; }
    public Address? ShippingAddress { get; private set; } = new(); // TODO change to not null after create address logic
    public List<OrderItem> Items { get; private set; } = [];

    public Order(int buyerId)
    {
        BuyerId = buyerId;
        StatusId = (int)OrderStatusEnum.Pending;
    }

    public void SetOrderStatus(OrderStatus status)
    {
        Status = status;
        StatusId = status.Id;
    }

    public void AddItem(int productId, decimal price, int sizeId, int quantity = 1)
    {
        if (Items.All(item => item.ProductId != productId || item.SizeId != sizeId))
        {
            Items.Add(new OrderItem(productId, sizeId, quantity, price));
            return;
        }

        var existingItem = Items.FirstOrDefault(item => item.ProductId == productId && item.SizeId == sizeId);
        existingItem?.IncreaseQuantity(quantity);
    }

    public void RemoveItem(int productId, int sizeId, int quantity = 1)
    {
        var item = Items.FirstOrDefault(orderItem => orderItem.ProductId == productId && orderItem.SizeId == sizeId);

        if (item == null) return;

        item.DecreaseQuantity(quantity);
    }
}
