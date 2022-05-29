namespace _4Teammate.Data.Repositories.Interfaces;

public interface IBaseRepository<T>
{
    public List<T> GetAll();
    public T GetById(int id);
    public T Create(T entity);
    public T Update(T entity);
    public void Delete(T entity);
}

