namespace Shop.Common
{
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public T? Value { get; private set; }
        public Error? Error { get; private set; }

        public Result(bool isSuccess, T? value, Error? error)
        {
            if (isSuccess && error is not null ||
                !isSuccess && error is null)
            {
                throw new ArgumentException("Invalid error", nameof(error));
            }

            IsSuccess = isSuccess;
            Value = isSuccess ? value : default;
            Error = isSuccess ? null : error;
        }

        public static Result<T> Success(T value) => new(true, value, default);

        public static Result<T> Failure(Error error) => new(false, default, error);
    }
}
