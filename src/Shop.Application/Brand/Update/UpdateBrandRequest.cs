using System.ComponentModel.DataAnnotations;

namespace Shop.Application.Brand.Update
{
    public sealed record UpdateBrandRequest([property: Required] string Name);

}
