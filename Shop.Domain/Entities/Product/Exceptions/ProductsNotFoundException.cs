namespace Shop.Domain.Entities.Product.Exceptions
{
    public sealed class ProductsNotFoundException : Exception
    {
        public ProductsNotFoundException()
            : base("Products not found in the database.")
        {

        }
    }
}
