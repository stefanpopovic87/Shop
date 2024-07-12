using System.ComponentModel.DataAnnotations;

namespace Shop.Application.Brand.Create
{
    public sealed record CreateBrandRequest([property: Required] string Name);

}
