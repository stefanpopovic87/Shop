using Shop.Domain.Entities.Base;
using Shop.Domain.Entities.Enums;
using Shop.Domain.Entities.Product;

namespace Shop.Domain.Entities.Order;

public class Order : BaseEntity
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
        base.Create();
        BuyerId = buyerId;
        StatusId = (int)OrderStatusEnum.Pending;
    }

    public void SetOrderStatus(OrderStatus status)
    {
        Status = status;
        StatusId = status.Id;
    }

    public void AddItem(Product.Product product, Size size, int quantity = 1)
    {
        if (Items.All(item => item.ProductId != product.Id || item.SizeId != size.Id))
        {
            Items.Add(new OrderItem(product, size, quantity, product.Price));
            return;
        }

        var existingItem = Items.FirstOrDefault(item => item.ProductId == product.Id && item.SizeId == size.Id);
        if (existingItem != null) existingItem.IncreaseQuantity(quantity);
    }

    public void RemoveItem(int productId, int sizeId, int quantity = 1)
    {
        var item = Items.FirstOrDefault(orderItem => orderItem.ProductId == productId && orderItem.SizeId == sizeId);

        if (item == null) return;

        item.DecreaseQuantity(quantity);
        if (item.Quantity == 0) item.Delete();
    }
}
