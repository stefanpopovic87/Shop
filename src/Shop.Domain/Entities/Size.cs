using Shop.Domain.Entities.Base;
using Shop.Domain.Entities.Products;

namespace Shop.Domain.Entities
{
    public class Size : BaseEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

        public ICollection<ProductSizeQuantity> SizeQuantities { get; private set; } = [];



        public Size(string name, int categoryId)
        {
            Create();
            Name = name;
            CategoryId = categoryId;
        }

        public void Update(string name, int categoryId)
        {
            Update();
            Name = name;
            CategoryId = categoryId;
        }
    }
}
