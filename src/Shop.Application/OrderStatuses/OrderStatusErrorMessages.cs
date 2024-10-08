using Shop.Common;

namespace Shop.Application.OrderStatuses
{
    public static class OrderStatusErrorMessages
    {
        #region Validation constants
        public const int MaxNameLength = 100;
        #endregion

        #region Validation error messages
        public static readonly Error NameIsRequired = new("OrderStatus.NameIsRequired", $"Name is required", ErrorTypeEnum.Validation);
        public static readonly Error NameTooLong = new("OrderStatus.NameTooLong", $"The order status name must not exceed {MaxNameLength} characters.", ErrorTypeEnum.Validation);
        public static readonly Error NameNotUnique = new("OrderStatus.NameNotUnique", $"The order status name should be unique", ErrorTypeEnum.Validation);
        #endregion

        #region Operational error messages
        public static readonly Error Creation = new("OrderSatus.Creation", $"Problem with order status creation", ErrorTypeEnum.Operational);
        public static readonly Error Update = new("OrderSatus.Update", $"Problem with order status update", ErrorTypeEnum.Operational);
        public static readonly Error Deletion = new("OrderSatus.Delete", $"Problem with order status deletion", ErrorTypeEnum.Operational);
        public static readonly Error NotFound = new("OrderStatus.NotFound", $"The order status was not found.", ErrorTypeEnum.Operational);
        public static readonly Error OrderStatusesNotFound = new("OrderStatus.OrderStatusesNotFound", $"Order statuses were not found in the database", ErrorTypeEnum.Operational);
        #endregion
    }
}
