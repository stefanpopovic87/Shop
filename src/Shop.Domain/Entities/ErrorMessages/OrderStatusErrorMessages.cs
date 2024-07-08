using Shop.Common;

namespace Shop.Domain.Entities.ErrorMessages
{
    public static class OrderStatusErrorMessages
    {
        public static readonly Error NotFound = new ("OrderStatus.NotFound", $"The order status was not found.");
    }
}
