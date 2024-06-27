namespace Shop.Domain.Entities.Product
{
    public class Size
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        public Size(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
