using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities.Order;

public class OrderItem : BaseEntity
{
    public int Id { get; private set; }
    public int OrderId { get; private set; }
    public Order Order { get; private set; } = new();
    public int Quantity { get; private set; }
    public int ProductId { get; private set; }
    public string SizeId { get; private set; } = string.Empty;
}
