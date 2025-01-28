namespace WatchListNetflix.Services;

public interface ICrudService<T> where T : class
{
    Task CreateAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);

    Task<ICollection<T>> GetAllAsync();

    Task<T> GetById(int id);

    Task<bool> SaveChangeAsync();
}
