using Shop.Common;

namespace Shop.Application.Brand
{
    public static class BrandErrorMessages
    {
        #region Validation constants
        public const int MaxNameLength = 100;
        #endregion

        #region Validation error messages
        public static readonly Error NameIsRequired = new("Brand.NameIsRequired", $"Name is required", ErrorTypeEnum.Validation);
        public static readonly Error NameTooLong = new("Brand.NameTooLong", $"The brand name must not exceed {MaxNameLength} characters.", ErrorTypeEnum.Validation);
        public static readonly Error NameNotUnique = new("Brand.NameNotUnique", $"The brand name should be unique", ErrorTypeEnum.Validation);
        #endregion

        #region Operational error messages
        public static readonly Error Creation = new("Brand.Creation", $"Problem with brand creation", ErrorTypeEnum.Operational);
        public static readonly Error Update = new("Brand.Update", $"Problem with brand update", ErrorTypeEnum.Operational);
        public static readonly Error Deletion = new("Brand.Delete", $"Problem with brand deletion", ErrorTypeEnum.Operational);
        public static readonly Error Activation = new("Brand.Activation", $"Problem with brand activation", ErrorTypeEnum.Operational);
        public static readonly Error BrandsNotFound = new("Brand.BrandsNotFound", $"Brands were not found in the database", ErrorTypeEnum.Operational);
        public static readonly Error NotFound = new("Brand.NotFound", $"The brand was not found.", ErrorTypeEnum.Operational);
        public static readonly Error AlreadyActive = new("Brand.AlreadyActive", $"Brand is already active", ErrorTypeEnum.Operational);
        #endregion
    }
}
