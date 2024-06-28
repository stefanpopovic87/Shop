namespace Shop.Domain.Entities.ErrorMessages
{
    public static class ProductSizeErrorMessages
    {
        public static string CreationError = $"Problem with product size creation.";
        public static string AlreadyExistError = $"Product with same size already exist.";
        public static string ProductsNotFound(int productId) => $"The products with Id = {productId} was not found.";
        public static string ProductSizeNotFound = $"The product size was not found.";
    }
}
