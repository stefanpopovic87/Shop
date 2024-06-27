namespace Shop.Domain.Entities.ErrorMessages
{
    public static class SizeErrorMessages
    {
        public static string SizeNotFound(int sizeId) => $"The size with Id = {sizeId} was not found.";

    }
}
