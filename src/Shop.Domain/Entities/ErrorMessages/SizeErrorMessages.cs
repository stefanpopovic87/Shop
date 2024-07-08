using Shop.Common;

namespace Shop.Domain.Entities.ErrorMessages
{
    public static class SizeErrorMessages
    {
        public static readonly Error NotFound = new("SizeNotFound.NotFound", $"The size was not found.");
    }
}
