using Shop.Common;

namespace Shop.Application.Size
{
    public static class SizeErrorMessages
    {
        #region Validation constants
        public const int MaxNameLength = 50;
        #endregion

        #region Validation error messages
        public static readonly Error NameIsRequired = new("Size.NameIsRequired", $"Name is required", ErrorTypeEnum.Validation);
        public static readonly Error NameTooLong = new("Size.NameTooLong", $"The size name must not exceed {MaxNameLength} characters", ErrorTypeEnum.Validation);
        public static readonly Error NameNotUniqueInCategory = new("Size.NameNotUniqueInCategory", $"The size name should be unique in category", ErrorTypeEnum.Validation);
        public static readonly Error CategoryNotExists = new("Size.CategoryNotExists", $"The category was not found.", ErrorTypeEnum.Validation);
        #endregion

        #region Operational error messages
        public static readonly Error Creation = new("Size.Creation", $"Problem with size creation", ErrorTypeEnum.Operational);
        public static readonly Error Update = new("Size.Update", $"Problem with size update", ErrorTypeEnum.Operational);
        public static readonly Error Deletion = new("Size.Delete", $"Problem with size deletion", ErrorTypeEnum.Operational);
        public static readonly Error Activation = new("Size.Activation", $"Problem with size activation", ErrorTypeEnum.Operational);
        public static readonly Error SizesNotFound = new("Size.SizesNotFound", $"Sizes were not found in the database", ErrorTypeEnum.Operational);
        public static readonly Error NotFound = new("Size.NotFound", $"The size was not found", ErrorTypeEnum.Operational);
        public static readonly Error AlreadyActive = new("Size.AlreadyActive", $"Size is already active", ErrorTypeEnum.Operational);
        #endregion
    }
}
