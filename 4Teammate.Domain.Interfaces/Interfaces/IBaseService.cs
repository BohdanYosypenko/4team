namespace _4Teammate.Domain.Services.Interfaces;

public interface IBaseService<T>
{
    public Task<List<T>> GetAllAsync();
    public Task<T> GetByIdAsync(int id);
    public Task<T> CreateAsync(T entity);
    public T Update(T entity);
    public void Delete(T entity);
}

