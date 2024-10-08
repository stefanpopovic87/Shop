namespace Shop.Application.Interfaces.UnitOfWork
{
    public interface IHistoryUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
