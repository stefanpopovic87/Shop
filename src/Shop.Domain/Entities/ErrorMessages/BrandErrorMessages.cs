using Shop.Common;

namespace Shop.Domain.Entities.ErrorMessages
{
    public static class BrandErrorMessages
    {
        public static readonly Error Creation = new("Brand.Creation", $"Problem with brand creation.");
        public static readonly Error Update = new("Brand.Update", $"Problem with brand update.");
        public static readonly Error Deletion = new("Brand.Delete", $"Problem with brand deletion.");
        public static readonly Error Activation = new("Brand.Activation", $"Problem with brand activation.");
        public static readonly Error BrandsNotFound = new("Brand.BrandsNotFound", $"Brands were not found in the database.");
        public static readonly Error NotFound = new("Brand.NotFound", $"The brand was not found.");
    }
}
