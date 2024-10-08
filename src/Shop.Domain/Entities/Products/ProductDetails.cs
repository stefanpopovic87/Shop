namespace Shop.Domain.Entities.Products
{
    public class ProductDetails
    {
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public string Code { get; }

        public ProductDetails(string name, string description, decimal price, string code)
        {
            Name = name;
            Description = description;
            Price = price;
            Code = code;
        }

        public ProductDetails(){}
    }

}
