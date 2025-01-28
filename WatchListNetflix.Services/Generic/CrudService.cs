using Microsoft.EntityFrameworkCore;
using WatchListNetflix.Data;
using WatchListNetflix.Model.Entities;

namespace WatchListNetflix.Services.Generic;

public abstract class CrudService<T> : ICrudService<T> where T : BaseEntity
{
    private readonly WatchListNetflixContext _db;

    public CrudService(WatchListNetflixContext db)
    {
        _db = db;
    }

    public virtual async Task CreateAsync(T entity)
    {
        try
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public virtual async Task DeleteAsync(T entity)
    {
        try
        {
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public virtual async Task<ICollection<T>> GetAllAsync()
    {
        return await _db.Set<T>().ToListAsync();
    }

    public virtual async Task<T> GetById(int id)
    {
        return await _db.Set<T>().FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task<bool> SaveChangeAsync()
    {
        return await _db.SaveChangesAsync() > 0;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        try
        {
            _db.Set<T>().Update(entity);
            await _db.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
