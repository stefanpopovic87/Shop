using Shop.Domain.Entities.Base;
using Shop.Domain.Entities.Products;

namespace Shop.Domain.Entities
{
    public class Gender : BaseEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        public ICollection<Product> Products { get; private set; } = [];

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
