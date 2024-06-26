namespace Shop.Domain.Entities.ErrorMessages
{
    public static class ProductErrorMessages
    {
        public static string CreationError = $"Problem with product creation.";
        public static string ProductsNotFound = $"Products not found in the database.";
        public static string ProductNotFound (int id) => $"The product with Id = {id} was not found.";

    }
}
