namespace Amigo.BAU.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        void Add(T entity);
        void Update(T entity, int id);
        void Delete(int id);
    }
}
