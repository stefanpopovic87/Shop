using Shop.Common;

namespace Shop.Domain.ErrorMessages
{
    public static class ProductErrorMessages
    {
        public static readonly Error Creation = new("Product.Creation", $"Problem with product creation.", ErrorTypeEnum.Operational);
        public static readonly Error Update = new("Product.Update", $"Problem with product update.", ErrorTypeEnum.Operational);
        public static readonly Error ProductsNotFound = new("Product.ProductsNotFound", $"Products were not found in the database.", ErrorTypeEnum.Operational);
        public static readonly Error NotFound = new("Product.NotFound", $"The product was not found.", ErrorTypeEnum.Operational);
    }
}
