namespace DotNetDevel.Repositories.Interface;

public interface IRepository<T>
{
    public Task<T> SaveAsync(T entity);
    public Task<T?> GetAsync<TR>(TR id);
    public Task<List<T>> GetAllAsync();
    public Task DeleteAsync(T entity);
    public Task SaveChangesAsync();
}