namespace Shop.Common
{
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public T? Value { get; private set; }
        public List<Error>? Errors { get; private set; }

        public Result(bool isSuccess, T? value, List<Error>? errors)
        {
            if (isSuccess && errors is not null && errors.Any() ||
                !isSuccess && (errors is null || !errors.Any()))
            {
                throw new ArgumentException("Invalid errors", nameof(errors));
            }

            IsSuccess = isSuccess;
            Value = isSuccess ? value : default;
            Errors = isSuccess ? null : errors;
        }

        public static Result<T> Success(T value) => new(true, value, null);

        public static Result<T> Failure(List<Error> errors) => new(false, default, errors);

        public static Result<T> Failure(Error error) => new(false, default, [error]);
    }
}
