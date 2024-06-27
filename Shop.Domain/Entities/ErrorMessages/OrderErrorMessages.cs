namespace Shop.Domain.Entities.ErrorMessages
{
    public static class OrderErrorMessages
    {
        public static string OrderNotFound = $"The order was not found.";
        public static string CreationError = $"Problem with order creation.";
        public static string DeletionError = $"Problem with order deletion.";
        public static string CreationQuantityError = $"Cannot select more than is in stock.";

    }
}
