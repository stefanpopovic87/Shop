namespace Shop.Domain.Interfaces.Base
{
    public interface IBaseRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken); 
        Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
        Task<bool> UniqueNameAsync(string name, CancellationToken cancellationToken);
    }
}
