using Shop.Common;

namespace Shop.Application.Products
{
    public static class ProductErrorMessages
    {
        #region Validation constants
        public const int MaxNameLength = 200;
        public const int MaxDescriptionLength = 200;
        public const int MaxCodeLength = 1000;
        public const int MinPriceValue = 0;
        public const int MaxPriceValue = 999999;
        public const int MinQuantityValue = 0; 
        public const int MaxQuantityValue = 999999;
        public const int MinBrandValue = 0;
        public const int MinSubcategoryValue = 0;
        public const int MinGenderValue = 0;
        #endregion

        #region Validation error messages
        public static readonly Error NameIsRequired = new("Product.NameIsRequired", $"Name is required", ErrorTypeEnum.Validation);
        public static readonly Error NameTooLong = new("Product.NameTooLong", $"The product name must not exceed {MaxNameLength} characters", ErrorTypeEnum.Validation);
        public static readonly Error DescriptionIsRequired = new("Product.DescriptionIsRequired", $"Description is required", ErrorTypeEnum.Validation);
        public static readonly Error DescriptionTooLong = new("Product.DescriptionTooLong", $"The product description must not exceed {MaxDescriptionLength} characters", ErrorTypeEnum.Validation);
        public static readonly Error CodeIsRequired = new("Product.CodeIsRequired", $"Code is required", ErrorTypeEnum.Validation);
        public static readonly Error CodeTooLong = new("Product.CodeTooLong", $"The product code must not exceed {MaxCodeLength} characters", ErrorTypeEnum.Validation);
        public static readonly Error PriceMinValue = new("Product.PriceMinValue", $"Price must be greater than {MinPriceValue}", ErrorTypeEnum.Validation);
        public static readonly Error PriceMaxValue = new("Product.PriceMaxValue", $"Price must be less than {MaxPriceValue}", ErrorTypeEnum.Validation);
        public static readonly Error BrandMinValue = new("Product.BrandMinValue", $"Brand must be greater than {MinBrandValue}", ErrorTypeEnum.Validation);
        public static readonly Error BrandNotExist = new("Product.BrandNotExist", $"The brand was not found", ErrorTypeEnum.Validation);
        public static readonly Error SubcategoryMinValue = new("Product.SubcategoryMinValue", $"Subcategory must be greater than {MinSubcategoryValue}", ErrorTypeEnum.Validation);
        public static readonly Error SubcategoryNotExist = new("Product.SubcategoryNotExist", $"The subcategory was not found", ErrorTypeEnum.Validation);
        public static readonly Error GenderMinValue = new("Product.GenderNotMinValue", $"Subcategory must be greater than {MinGenderValue}", ErrorTypeEnum.Validation);
        public static readonly Error GenderNotExist = new("Product.GenderNotExist", $"The gender was not found", ErrorTypeEnum.Validation);
        public static readonly Error QuantityMinValue = new("Product.QuantityMinValue", $"Quantity must be greater than {MinQuantityValue}", ErrorTypeEnum.Validation);
        public static readonly Error QuantityMaxValue = new("Product.QuantityMaxValue", $"Quantity must be less than {MaxQuantityValue}", ErrorTypeEnum.Validation);
        public static readonly Error SizeNotExist = new("Product.SizeNotExist", $"The size was not found", ErrorTypeEnum.Validation);
        public static readonly Error SizeQuantitiesCannotBeNull = new("Product.SizeQuantitiesCannotBeNull", $"The list of size quantities cannot be null", ErrorTypeEnum.Validation);
        public static readonly Error SizeQuantitiesMustContainItems = new("Product.SizeQuantitiesMustContainItems", $"The list of size quantities must contain at least one item", ErrorTypeEnum.Validation);
        #endregion

        #region Operational error messages
        public static readonly Error Creation = new("Product.Creation", $"Problem with size creation", ErrorTypeEnum.Operational);
        public static readonly Error Update = new("Product.Update", $"Problem with size update", ErrorTypeEnum.Operational);
        public static readonly Error Deletion = new("Product.Deletion", $"Problem with size deletion", ErrorTypeEnum.Operational);
        public static readonly Error Activation = new("Product.Activation", $"Problem with size activation", ErrorTypeEnum.Operational);
        public static readonly Error SizesNotFound = new("Product.SizesNotFound", $"Sizes were not found in the database", ErrorTypeEnum.Operational);
        public static readonly Error NotFound = new("Product.NotFound", $"The product was not found", ErrorTypeEnum.Operational);
        public static readonly Error AlreadyActive = new("Product.AlreadyActive", $"Size is already active", ErrorTypeEnum.Operational);
        #endregion
    }
}
