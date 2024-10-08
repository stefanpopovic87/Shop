namespace Shop.Domain.Entities.Orders;

public class OrderItem
{
    public int Id { get; private set; }
    public int OrderId { get; private set; }
    public Order Order { get; private set; }
    public int Quantity { get; private set; }
    public int ProductId { get; private set; }
    public int SizeId { get; private set; }
    public decimal Price { get; private set; }

    private OrderItem() { }

    public OrderItem(int productId, int sizeId, int quantity, decimal price)
    {
        ProductId = productId; 
        SizeId = sizeId;
        Quantity = quantity;
        Price = price;
    }

    public void IncreaseQuantity(int quantity)
    {
        Quantity += quantity;
    }

    public void DecreaseQuantity(int quantity)
    {
        Quantity -= quantity;
    }
}
