namespace Shop.Application.Interfaces
{
    public interface IHistoryUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
