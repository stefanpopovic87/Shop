using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities
{
    public class Category : BaseEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        public ICollection<Subcategory> Subcategories { get; private set; } = new List<Subcategory>();
        public ICollection<Size> Sizes { get; private set; } = new List<Size>();


        public Category(string name)
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