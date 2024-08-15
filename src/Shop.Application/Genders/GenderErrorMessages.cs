using Shop.Common;

namespace Shop.Application.Genders
{
    public static class GenderErrorMessages
    {
        #region Validation constants
        public const int MaxNameLength = 50;
        #endregion

        #region Validation error messages
        public static readonly Error NameIsRequired = new("Gender.NameIsRequired", $"Name is required", ErrorTypeEnum.Validation);
        public static readonly Error NameTooLong = new("Gender.NameTooLong", $"The gender name must not exceed {MaxNameLength} characters.", ErrorTypeEnum.Validation);
        public static readonly Error NameNotUnique = new("Gender.NameNotUnique", $"The gender name should be unique", ErrorTypeEnum.Validation);
        #endregion

        #region Operational error messages
        public static readonly Error Creation = new("Gender.Creation", $"Problem with gender creation", ErrorTypeEnum.Operational);
        public static readonly Error Update = new("Gender.Update", $"Problem with gender update", ErrorTypeEnum.Operational);
        public static readonly Error Deletion = new("Gender.Delete", $"Problem with gender deletion", ErrorTypeEnum.Operational);
        public static readonly Error Activation = new("Gender.Activation", $"Problem with gender activation", ErrorTypeEnum.Operational);
        public static readonly Error GendersNotFound = new("Gender.GendersNotFound", $"Genders were not found in the database", ErrorTypeEnum.Operational);
        public static readonly Error NotFound = new("Gender.NotFound", $"The gender was not found.", ErrorTypeEnum.Operational);
        public static readonly Error AlreadyActive = new("Gender.AlreadyActive", $"Gender is already active", ErrorTypeEnum.Operational);
        #endregion
    }
}
