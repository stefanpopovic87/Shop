using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities.Orders;

public class OrderItem : BaseEntity
{
    public int Id { get; private set; }
    public int OrderId { get; private set; }
    public Order Order { get; private set; }
    public int Quantity { get; private set; }
    public int ProductId { get; private set; }
    public Products.Product Product { get; private set; }
    public int SizeId { get; private set; }
    public Size Size { get; private set; }
    public decimal Price { get; private set; }

    private OrderItem() { }

    public OrderItem(Products.Product product, Size size, int quantity, decimal price)
    {
        Product = product;
        ProductId = product.Id; 
        Size = size;
        SizeId = size.Id;
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
