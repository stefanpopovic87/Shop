namespace Shop.Common
{
    public class ErrorResult
    {
        public bool IsSuccess { get; set; } = false;
        public object? Value { get; set; } = null;
        public ErrorDetail Error { get; set; }

        public ErrorResult(string code, string description)
        {
            Error = new ErrorDetail { Code = code, Description = description };
        }
    }

    public class ErrorDetail
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
