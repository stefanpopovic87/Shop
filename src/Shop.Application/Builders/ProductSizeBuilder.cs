namespace Shop.Application.Builders
{
    internal class ProductSizeBuilder
    {
        private readonly List<(int SizeId, int Quantity)> _sizeQuantities = new();

        private ProductSizeBuilder()
        {
        }

        public static ProductSizeBuilder StartBuildingSizes() => new();

        public ProductSizeBuilder AddSizeQuantity(int sizeId, int quantity)
        {
            _sizeQuantities.Add((sizeId, quantity));
            return this;
        }

        public ProductSizeBuilder AddSizeQuantities(IEnumerable<(int SizeId, int Quantity)> sizeQuantities)
        {
            _sizeQuantities.AddRange(sizeQuantities);
            return this;
        }

        public IEnumerable<(int SizeId, int Quantity)> Build()
        {
            return _sizeQuantities;
        }
    }
}
