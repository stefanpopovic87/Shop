namespace Shop.Common
{
    public sealed record Error(string Code, string Description, ErrorTypeEnum ErrorType)
    {
    }
}
