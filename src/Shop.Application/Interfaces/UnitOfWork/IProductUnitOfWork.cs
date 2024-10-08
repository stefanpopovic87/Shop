namespace Shop.Application.Interfaces.UnitOfWork
{
    public interface IProductUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
