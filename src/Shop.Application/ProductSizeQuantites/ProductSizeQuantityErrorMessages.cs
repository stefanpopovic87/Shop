using Shop.Common;

namespace Shop.Application.ProductSizeQuantites
{
    public static class ProductSizeQuantityErrorMessages
    {
        #region Validation constants
        public static readonly int QuantityGreaterThan = 0;
        #endregion

        #region Validation error messages
        public static readonly Error QuantityShouldBeGreaterThan = new("ProductSizeQuantity.QuantityShouldBeGreaterThan", $"The quantity should be greater than {QuantityGreaterThan}", ErrorTypeEnum.Validation);
        public static readonly Error ProductIdIsRequired = new("ProductSizeQuantity.ProductIdIsRequired", $"The product id is required", ErrorTypeEnum.Validation);
        public static readonly Error SizeIdIsRequired = new("ProductSizeQuantity.SizeIdIsRequired", $"The size id is required", ErrorTypeEnum.Validation);
        public static readonly Error ProductNotExists = new("ProductSizeQuantity.ProductNotExists", $"The product was not found", ErrorTypeEnum.Validation);
        public static readonly Error SizeNotExists = new("ProductSizeQuantity.SizeNotExists", $"The size was not found", ErrorTypeEnum.Validation);
        public static readonly Error NotUnique = new("ProductSizeQuantity.NotUnique", $"The product by size should be unique", ErrorTypeEnum.Validation);
        #endregion

        #region Operational error messages
        public static readonly Error Creation = new("ProductSizeQuantity.Creation", $"Problem with ProductSizeQuantity creation", ErrorTypeEnum.Operational);
        public static readonly Error Update = new("ProductSizeQuantity.Update", $"Problem with ProductSizeQuantity update", ErrorTypeEnum.Operational);
        public static readonly Error Deletion = new("ProductSizeQuantity.Delete", $"Problem with ProductSizeQuantity deletion", ErrorTypeEnum.Operational);
        public static readonly Error Activation = new("ProductSizeQuantity.Activation", $"Problem with ProductSizeQuantity activation", ErrorTypeEnum.Operational);
        public static readonly Error ProductSizeQuantitiesNotFound = new("ProductSizeQuantity.ProductSizeQuantitiesNotFound", $"ProductSizeQuantities were not found in the database", ErrorTypeEnum.Operational);
        public static readonly Error NotFound = new("ProductSizeQuantity.NotFound", $"The product for size was not found", ErrorTypeEnum.Operational);
        public static readonly Error AlreadyActive = new("ProductSizeQuantityErrorMessages.AlreadyActive", $"the product for size is already active", ErrorTypeEnum.Operational);
        #endregion

    }
}
