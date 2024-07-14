using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities.Product
{
    public class Size : BaseEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

        public ICollection<ProductSizeQuantity> SizeQuantities { get; private set; } = new List<ProductSizeQuantity>();



        public Size(string name, int categoryId)
        {
            base.Create();
            Name = name;
            CategoryId = categoryId;
        }

        public void Update(string name, int categoryId)
        {
            base.Update();
            Name = name;
            CategoryId = categoryId;
        }
    }
}
