namespace Shop.Domain.Entities
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        public ICollection<Subcategory> Subcategories { get; private set; } = [];
        public ICollection<Size> Sizes { get; private set; } = [];

        public static Category Create(string name) 
        { 
            return new Category(name);
        }

        public void Update(string name)
        {
            Name = name;
        }

        private Category(string name)
        {
            Name = name;
        }
    }
}