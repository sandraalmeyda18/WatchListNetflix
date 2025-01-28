namespace WatchListNetflix.Services.Generic;

public interface ICrudService<T> where T : class
{
    Task CreateAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);

    Task<List<T>> GetAllAsync();

    Task<T> GetById(int id);

    Task<bool> SaveChangeAsync();
}
