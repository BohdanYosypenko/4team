namespace _4Teammate.Domain.Services.Interfaces;

public interface IBaseService<T>
{
    public List<T> GetAll();
    public T GetById(int id);
    public T Create(T entity);
    public T Update(T entity);
    public void Delete(T entity);
}

