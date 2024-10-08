namespace Shop.Application.Interfaces.UnitOfWork
{
    public interface IOrderUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
