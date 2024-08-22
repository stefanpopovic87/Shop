using Shop.Domain.Entities.Products;

namespace Shop.Domain.Entities
{
    public class Size
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

        public ICollection<ProductSizeQuantity> SizeQuantities { get; private set; } = [];



        public Size(string name, int categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }

        public void Update(string name, int categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }
    }
}
