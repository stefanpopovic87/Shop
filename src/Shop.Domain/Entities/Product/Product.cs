using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities.Product;

public class Product : BaseEntity
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public string? PictureUrl { get; private set; } = string.Empty; // TODO Add logic for storing picture

    public Product(string name, string description, decimal price, string? pictureUrl)
    {
        base.Create();

        Name = name;
        Description = description;
        Price = price;
        PictureUrl = pictureUrl;        
    }

    public void Update(string name, string description, decimal price, string? pictureUrl)
    {
        base.Update();

        Name = name;
        Description = description;
        Price = price;
        PictureUrl = pictureUrl;
    }
}
