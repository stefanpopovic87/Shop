using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities.Product
{
    public class ProductSizeQuantity : BaseEntity
    {
        public int ProductId { get; private set; }
        public Product Product { get; private set; }

        public int SizeId { get; private set; }
        public Size Size { get; private set; }

        public int QuantityInStock { get; private set; }

        public ProductSizeQuantity(int productId, int sizeId, int quantityInStock)
        {
            base.Create();
            ProductId = productId;
            SizeId = sizeId;
            QuantityInStock = quantityInStock;
        }

        public ProductSizeQuantity(int sizeId, int quantityInStock)
        {
            base.Create();
            SizeId = sizeId;
            QuantityInStock = quantityInStock;
        }

        public void Update (int sizeId, int quantityInStock)
        {
            base.Update();
            SizeId = sizeId;
            QuantityInStock = quantityInStock;
        }

        public void UpdateQuantityInStock(int quantityInStock)
        {
            QuantityInStock = quantityInStock;
        }

        public void IncreaseQuantity(int quantity)
        {
            QuantityInStock += quantity;
        }

        public void DecreaseQuantity(int quantity)
        {
            QuantityInStock -= quantity;
        }
    }
}
