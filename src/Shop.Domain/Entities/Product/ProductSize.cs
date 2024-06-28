using Shop.Domain.Entities.Base;
using System.Drawing;

namespace Shop.Domain.Entities.Product
{
    public class ProductSize : BaseEntity
    {
        public int ProductId { get; private set; }
        public int SizeId { get; private set; }

        public int QuantityInStock { get; private set; }

        public Product Product { get; private set; }
        public Size Size { get; private set; }

        public ProductSize(int productId, int sizeId, int quantityInStock)
        {
            base.Create();

            ProductId = productId;
            SizeId = sizeId;
            QuantityInStock = quantityInStock;
        }

        public void UpdateQuantity (int quantityInStock)
        {
            base.Update();

            QuantityInStock = quantityInStock;
        }

        public void IncreaseQuantity(int quantity)
        {
            base.Update();

            QuantityInStock += quantity;
        }

        public void DecreaseQuantity(int quantity)
        {
            base.Update();

            QuantityInStock -= quantity;
        }
    }
}
