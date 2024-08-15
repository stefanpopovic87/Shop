using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities;

public class Basket : BaseEntity
{
    public int Id { get; set; }
    public int BuyerId { get; set; }
    public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    public string PaymentIntentId { get; set; }
    public string ClientSecret { get; set; }

    public void AddItem(Products.Product product, int quantity)
    {
        if (Items.All(item => item.ProductId != product.Id))
        {
            Items.Add(new BasketItem { Product = product, Quantity = quantity });
            return;
        }

        var existingItem = Items.FirstOrDefault(item => item.ProductId == product.Id);
        if (existingItem != null) existingItem.Quantity += quantity;
    }

    public void RemoveItem(int productId, int quantity = 1)
    {
        var item = Items.FirstOrDefault(basketItem => basketItem.ProductId == productId);
        if (item == null) return;
        item.Quantity -= quantity;
        if (item.Quantity == 0) Items.Remove(item);
    }
}
