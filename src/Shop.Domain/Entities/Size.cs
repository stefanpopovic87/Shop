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

        public static Size Create(string name, int categoryId)
        {
            return new Size(name, categoryId);
        }

        public void Update(string name, int categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }

        private Size(string name, int categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }
    }
}
