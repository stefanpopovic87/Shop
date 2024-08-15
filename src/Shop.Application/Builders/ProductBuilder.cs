using Shop.Domain.Entities.Products;

namespace Shop.Application.Builders
{
    internal class ProductBuilder
    {
        private int _brandId;
        private int _subcategoryId;
        private int _genderId;
        private readonly ProductDetailBuilder _detailBuilder = ProductDetailBuilder.StartBuilding();
        private readonly List<(int SizeId, int Quantity)> _sizeQuantities = new();

        private ProductBuilder()
        {
        }

        public static ProductBuilder StartBuildingProduct() => new();

        public ProductBuilder WithDetails(Action<ProductDetailBuilder> action)
        {
            action(_detailBuilder);
            return this;
        }

        public ProductBuilder AssignedBrand(int brandId)
        {
            _brandId = brandId;
            return this;
        }

        public ProductBuilder BelongingToSubcategory(int subcategoryId)
        {
            _subcategoryId = subcategoryId;
            return this;
        }

        public ProductBuilder ForGender(int genderId)
        {
            _genderId = genderId;
            return this;
        }

        public ProductBuilder WithSizeAndQuantities(IEnumerable<(int SizeId, int Quantity)> sizeQuantities)
        {
            var sizeBuilder = ProductSizeBuilder.StartBuildingSizes()
                .AddSizeQuantities(sizeQuantities);

            _sizeQuantities.AddRange(sizeBuilder.Build());
            return this;
        }

        public Product Build()
        {
            var product = new Product(
                _detailBuilder.Build(),
                _brandId,
                _subcategoryId,
                _genderId);

            foreach (var (sizeId, quantity) in _sizeQuantities)
            {
                product.AddSizeQuantity(sizeId, quantity);
            }

            return product;
        }
    }
}
