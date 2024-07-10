using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities.Product
{
    public class Subcategory : BaseEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

        public ICollection<Product> Products { get; private set; } = new List<Product>();

        public Subcategory(string name, int categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }
    }
}
