using Shop.Common;

namespace Shop.Domain.Entities.ErrorMessages
{
    public static class OrderErrorMessages
    {
        public static readonly Error NotFound = new ("Order.NotFound", $"The order was not found.");
        public static readonly Error Creation = new ("Order.Creation", $"Problem with order creation.");
        public static readonly Error Deletion = new ("Order.Deletion", $"Problem with order deletion.");
        public static readonly Error CreationQuantity = new ("Order.CreationQuantity", $"Cannot select more than is in stock.");
    }
}
