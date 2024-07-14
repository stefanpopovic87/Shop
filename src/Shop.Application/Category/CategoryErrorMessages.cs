using Shop.Common;

namespace Shop.Application.Category
{
    public static class CategoryErrorMessages
    {
        #region Validation constants
        public const int MaxNameLength = 50;
        #endregion

        #region Validation error messages
        public static readonly Error NameIsRequired = new("Category.NameIsRequired", $"Name is required", ErrorTypeEnum.Validation);
        public static Error NameTooLong = new("Category.NameTooLong", $"The category name must not exceed {MaxNameLength } characters.", ErrorTypeEnum.Validation);
        public static readonly Error NotUnique = new("Category.NotUnique", $"The category name should be unique", ErrorTypeEnum.Validation);
        #endregion

        #region Operational error messages
        public static readonly Error Creation = new("Category.Creation", $"Problem with category creation", ErrorTypeEnum.Operational);
        public static readonly Error Update = new("Category.Update", $"Problem with category update", ErrorTypeEnum.Operational);
        public static readonly Error Deletion = new("Category.Delete", $"Problem with category deletion", ErrorTypeEnum.Operational);
        public static readonly Error Activation = new("Category.Activation", $"Problem with category activation", ErrorTypeEnum.Operational);
        public static readonly Error CategoriesNotFound = new("Category.CategoriesNotFound", $"Categories were not found in the database", ErrorTypeEnum.Operational);
        public static readonly Error NotFound = new("Category.NotFound", $"The category was not found.", ErrorTypeEnum.Operational);
        public static readonly Error AlreadyActive = new("Category.AlreadyActive", $"Category is already active", ErrorTypeEnum.Operational);
        #endregion
    }
}
