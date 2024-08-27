using Shop.Domain.Entities.Products;

namespace Shop.Domain.Entities
{
    public class Gender
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        public ICollection<Product> Products { get; private set; } = [];

        public static Gender Create(string name)
        {
            return new Gender(name);
        }

        public void Update(string name)
        {
            Name = name;
        }

        private Gender(string name)
        {
            Name = name;
        }
    }
}
