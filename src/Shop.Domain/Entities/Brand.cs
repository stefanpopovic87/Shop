using Shop.Domain.Entities.Base;
using Shop.Domain.Entities.Products;

namespace Shop.Domain.Entities
{
    public class Brand : BaseEntity
    {
        #region Properties
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public ICollection<Product> Products { get; private set; } = [];
        #endregion

        #region Methods
        public Brand(string name)
        {
            Create();
            Name = name;
        }

        public void Update(string name)
        {
            Update();
            Name = name;
        }
        #endregion

    }
}
