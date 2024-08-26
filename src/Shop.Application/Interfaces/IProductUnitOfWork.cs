namespace Shop.Application.Interfaces
{
    public interface IProductUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
