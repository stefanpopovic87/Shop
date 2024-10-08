namespace Shop.Domain.Entities.Orders
{
    public class OrderStatus
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        public static OrderStatus Create(string name)
        {
            return new OrderStatus(name);
        }

        public void Update(string name)
        {
            Name = name;
        }

        private OrderStatus(string name)
        {
            Name = name;
        }
    }
}
