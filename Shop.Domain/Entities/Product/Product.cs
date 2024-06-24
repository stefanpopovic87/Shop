using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities.Product;

public class Product : BaseEntity
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public string? PictureUrl { get; private set; } = string.Empty;

    public static Product Create(string name, string description, decimal price, string? pictureUrl)
    {
        return new Product
        {
            Name = name,
            Description = description,
            Price = price,
            PictureUrl = pictureUrl
        }; 
    }

    public Product Update(string name, string description, decimal price, string? pictureUrl)
    {
        Name = name;
        Description = description;
        Price = price;
        PictureUrl = pictureUrl;

        return this;
    }
}
