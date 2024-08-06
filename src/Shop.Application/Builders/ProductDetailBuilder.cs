using ProductEntities = Shop.Domain.Entities.Product;

namespace Shop.Application.Builders
{
    internal sealed class ProductDetailBuilder
    {
        private string _name;
        private string _description;
        private decimal _price;
        private string _code;

        private ProductDetailBuilder()
        {
        }

        public static ProductDetailBuilder StartBuilding() => new();

        public ProductDetailBuilder Named(string name)
        {
            _name = name;
            return this;
        }

        public ProductDetailBuilder Described(string description)
        {
            _description = description;
            return this;
        }

        public ProductDetailBuilder PriceOf(decimal price)
        {
            _price = price;
            return this;
        }

        public ProductDetailBuilder WithCode(string code)
        {
            _code = code;
            return this;
        }

        public ProductEntities.ProductDetails Build()
        {
            return new ProductEntities.ProductDetails(_name, _description, _price, _code);
        }

    }
}
