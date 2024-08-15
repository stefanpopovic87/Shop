using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities.Orders
{
    public class OrderStatus : BaseEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        public OrderStatus(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
