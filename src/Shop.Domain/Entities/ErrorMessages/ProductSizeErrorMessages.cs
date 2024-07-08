using Shop.Common;

namespace Shop.Domain.Entities.ErrorMessages
{
    public static class ProductSizeErrorMessages
    {
        public static readonly Error Creation = new("ProductSize.Creation", $"Problem with product size creation.");
        public static readonly Error AlreadyExist = new("ProductSize.AlreadyExist", $"Product with same size already exist.");
        public static readonly Error ProductsNotFound = new("ProductSize.ProductsNotFound", $"The products was not found.");
        public static readonly Error NotFound = new("ProductSize.NotFound", $"The product size was not found.");
    }
}
