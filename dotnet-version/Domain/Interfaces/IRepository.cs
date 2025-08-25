namespace Domain.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T? Get(Guid id);
        Guid Create(T entity);
        bool Update(T entity);
        bool Delete(Guid id);
    }
}
