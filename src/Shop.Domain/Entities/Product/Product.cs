using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities.Product;

public class Product : BaseEntity
{
    public int Id { get; private set; }
    public ProductDetails Details { get; private set; }

    public int BrandId { get; private set; }
    public Brand Brand { get; private set; }

    public int SubcategoryId { get; private set; }
    public Subcategory Subcategory { get; private set; }

    public int GenderId { get; private set; }
    public Gender Gender { get; private set; }

    public ICollection<ProductSizeQuantity> SizeQuantities { get; private set; } = new List<ProductSizeQuantity>();

    private Product() { }


    public Product(ProductDetails details, int brandId, int subcategoryId, int genderId)
    {
        base.Create();
        Details = details;
        BrandId = brandId;
        SubcategoryId = subcategoryId;
        GenderId = genderId;
    }

    public void Update(ProductDetails details, int brandId, int subcategoryId, int genderId)
    {
        base.Update();
        Details = details;
        BrandId = brandId;
        SubcategoryId = subcategoryId;
        GenderId = genderId;
    }

    public void AddSizeQuantity(int sizeId, int quantity)
    {
        SizeQuantities.Add(new ProductSizeQuantity(sizeId, quantity));
    }
}
