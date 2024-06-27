namespace Shop.Domain.Entities.ErrorMessages
{
    public static class OrderStatusErrorMessages
    {
        public static string OrderStatusNotFound(int statusId) => $"The order status with Id = {statusId} was not found.";

    }
}
