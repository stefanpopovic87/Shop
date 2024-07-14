using Shop.Common;

namespace Shop.Domain.ErrorMessages
{
    public static class OrderErrorMessages
    {
        public static readonly Error NotFound = new ("Order.NotFound", $"The order was not found.", ErrorTypeEnum.Operational);
        public static readonly Error Creation = new ("Order.Creation", $"Problem with order creation.", ErrorTypeEnum.Operational);
        public static readonly Error Deletion = new ("Order.Deletion", $"Problem with order deletion.", ErrorTypeEnum.Operational);
        public static readonly Error CreationQuantity = new ("Order.CreationQuantity", $"Cannot select more than is in stock.", ErrorTypeEnum.Operational);
    }
}
