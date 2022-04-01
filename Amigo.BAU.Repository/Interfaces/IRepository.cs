namespace Amigo.BAU.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        TEntity Add(TEntity entity);
        void Update(TEntity entity, int id);
        void Delete(int id);
    }
}
