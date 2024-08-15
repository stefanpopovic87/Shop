using Shop.Common;

namespace Shop.Application.Subcategories
{
    public static class SubcategoryErrorMessages
    {
        #region Validation constants
        public const int MaxNameLength = 200;
        #endregion

        #region Validation error messages
        public static readonly Error NameIsRequired = new("Subcategory.NameIsRequired", $"Name is required", ErrorTypeEnum.Validation);
        public static readonly Error NameTooLong = new("Subcategory.NameTooLong", $"The subcategory name must not exceed {MaxNameLength} characters.", ErrorTypeEnum.Validation);
        public static readonly Error NameNotUniqueInCategory = new("Subcategory.NameNotUniqueInCategory", $"The subcategory name should be unique in category", ErrorTypeEnum.Validation);
        public static readonly Error CategoryNotExist = new("Subcategory.CategoryNotExist", $"The category was not found.", ErrorTypeEnum.Validation);
        #endregion

        #region Operational error messages
        public static readonly Error Creation = new("Subcategory.Creation", $"Problem with subcategory creation", ErrorTypeEnum.Operational);
        public static readonly Error Update = new("Subcategory.Update", $"Problem with subcategory update", ErrorTypeEnum.Operational);
        public static readonly Error Deletion = new("Subcategory.Delete", $"Problem with subcategory deletion", ErrorTypeEnum.Operational);
        public static readonly Error Activation = new("Subcategory.Activation", $"Problem with subcategory activation", ErrorTypeEnum.Operational);
        public static readonly Error SubcategoriesNotFound = new("Subcategory.SubcategoriesNotFound", $"Subcategories were not found in the database", ErrorTypeEnum.Operational);
        public static readonly Error NotFound = new("Subcategory.NotFound", $"The subcategory was not found.", ErrorTypeEnum.Operational);
        public static readonly Error AlreadyActive = new("Subcategory.AlreadyActive", $"Subcategory is already active", ErrorTypeEnum.Operational);
        #endregion
    }
}
