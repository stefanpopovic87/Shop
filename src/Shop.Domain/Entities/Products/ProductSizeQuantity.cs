namespace Shop.Domain.Entities.Products
{
    public class ProductSizeQuantity
    {
        public int ProductId { get; private set; }
        public Product Product { get; private set; }

        public int SizeId { get; private set; }
        public Size Size { get; private set; }

        public int QuantityInStock { get; private set; }

        public static ProductSizeQuantity Create(int productId, int sizeId, int quantityInStock)
        {
            return new ProductSizeQuantity(productId, sizeId, quantityInStock);
        }

        public ProductSizeQuantity(int sizeId, int quantityInStock)
        {
            SizeId = sizeId;
            QuantityInStock = quantityInStock;
        }

        public void Update (int sizeId, int quantityInStock)
        {
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

        private ProductSizeQuantity(int productId, int sizeId, int quantityInStock)
        {
            ProductId = productId;
            SizeId = sizeId;
            QuantityInStock = quantityInStock;
        }
    }
}
