namespace Shop.Domain.Entities.Product.Exceptions
{
    public sealed class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(int productId)
            : base($"The product with Id = {productId} was tot found.")
        {
            
        }
    }
}
