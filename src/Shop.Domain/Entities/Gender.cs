using Shop.Domain.Entities.Base;
using ProductEntities = Shop.Domain.Entities.Product;

namespace Shop.Domain.Entities
{
    public class Gender : BaseEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        public ICollection<ProductEntities.Product> Products { get; private set; } = new List<ProductEntities.Product>();

        public Gender(string name)
        {
            Create();
            Name = name;
        }

        public void Update(string name)
        {
            Update();
            Name = name;
        }
    }
}
