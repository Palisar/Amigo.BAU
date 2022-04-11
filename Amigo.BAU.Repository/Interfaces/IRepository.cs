namespace Amigo.BAU.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<TEntity>Add(TEntity entity);
        Task Update(TEntity entity, int id);
        Task Delete(int id);
    }
}
