using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities.Product;

public class Product : BaseEntity
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }

    public string Code {  get; private set; } = string.Empty;

    public int BrandId { get; private set; }
    public Brand Brand { get; private set; }

    public int SubcategoryId { get; private set; }
    public Subcategory Subcategory { get; private set; }

    public int GenderId { get; private set; }
    public Gender Gender { get; private set; }

    public ICollection<ProductQuantity> ProductQuantities { get; private set; } = new List<ProductQuantity>();

    public Product(string name, string description, decimal price, string code, int brandId, int subcategoryId, int genderId)
    {
        base.Create();

        Name = name;
        Description = description;
        Price = price;
        Code = code;
        BrandId = brandId;
        SubcategoryId = subcategoryId;
        GenderId = genderId;
    }

    public void Update(string name, string description, decimal price, string code, int brandId, int subcategoryId, int genderId)
    {
        base.Update();

        Name = name;
        Description = description;
        Price = price;
        Code = code;
        BrandId = brandId;
        Code = code;
        SubcategoryId = subcategoryId;
        GenderId = genderId;
    }
}
