using Shop.Common;

namespace Shop.Domain.Entities.ErrorMessages
{
    public static class ProductErrorMessages
    {
        public static readonly Error Creation = new("Product.Creation", $"Problem with product creation.");
        public static readonly Error Update = new("Product.Update", $"Problem with product update.");
        public static readonly Error ProductsNotFound = new("Product.ProductsNotFound", $"Products not found in the database.");
        public static readonly Error NotFound = new("Product.NotFound", $"The product was not found.");
    }
}
