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

            var validationErrors = validationResult.Errors;
            List<Error> errros = validationErrors.Select(x => new Error(x.ErrorCode, x.ErrorMessage, ErrorTypeEnum.Validation)).ToList();
            return Result<T>.Failure(errros);
        }
    }
}
