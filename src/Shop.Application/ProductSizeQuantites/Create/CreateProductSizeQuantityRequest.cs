namespace Shop.Application.ProductSizeQuantites.Create
{
    public sealed record CreateProductSizeQuantityRequest(int ProductId, int SizeId, int QuantityInStock);
}
