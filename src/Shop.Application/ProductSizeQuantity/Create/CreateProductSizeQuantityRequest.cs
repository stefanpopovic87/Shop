namespace Shop.Application.ProductSizeQuantity.Create
{
    public sealed record CreateProductSizeQuantityRequest(int ProductId, int SizeId, int QuantityInStock);
}
