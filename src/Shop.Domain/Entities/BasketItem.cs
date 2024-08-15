using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities;

public class BasketItem : BaseEntity
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public Products.Product Product { get; set; }
    public int BasketId { get; set; }
    public Basket Basket { get; set; }
}
