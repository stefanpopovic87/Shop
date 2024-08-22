namespace Shop.Domain.Entities
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        public ICollection<Subcategory> Subcategories { get; private set; } = new List<Subcategory>();
        public ICollection<Size> Sizes { get; private set; } = new List<Size>();


        public Category(string name)
        {
            Name = name;
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}