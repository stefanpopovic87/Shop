using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities.Product
{
    public class ProductSize : BaseEntity
    {
        public int ProductId { get; private set; }
        public int SizeId { get; private set; }

        public int QuantityInStock { get; private set; }

        public Product Product { get; private set; }
        public Size Size { get; private set; }

    }
}
