using FluentValidation.Results;
using Shop.Common;

namespace Shop.Application.Helpers
{
    public static class ValidationErrorHelper
    {
        public static Result<T> CreateValidationErrorResult<T>(ValidationResult validationResult)
        {
            if (validationResult.IsValid)
            {
                throw new InvalidOperationException("Validation result is valid, no errors to process.");
            }

            var firstError = validationResult.Errors.First();
            var error = new Error(firstError.ErrorCode, firstError.ErrorMessage, ErrorTypeEnum.Validation);
            return Result<T>.Failure(error);
        }
    }
}
