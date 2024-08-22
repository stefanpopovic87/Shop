using Shop.Domain.Entities.Products;

namespace Shop.Domain.Entities
{
    public class Brand
    {
        #region Properties
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public ICollection<Product> Products { get; private set; } = [];
        #endregion

        #region Methods
        public Brand(string name)
        {
            Name = name;
        }

        public void Update(string name)
        {
            Name = name;
        }
        #endregion

    }
}
