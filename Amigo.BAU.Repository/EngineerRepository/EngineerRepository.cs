using Amigo.BAU.Persistance.Models;
using Amigo.BAU.Persistance.QueryModels;
using Dapper;
using System.Data;
using System.Data.Common;

namespace Amigo.BAU.Repository.EngineerRepository
{
    public class EngineerRepository : IEngineerRepository, IDisposable
    {
        private readonly IDbConnection _db;
        public EngineerRepository(DbConnection db)
        {
            _db = db;
        }
        //TODO : Add unit of work pattern
        public IEnumerable<Engineer> GetAll()
        {
           return _db.Query<Engineer>("SELECT * FROM Engineers");
        }

        public IEnumerable<ShiftWorker> GetNamedEngineers()
        {
            return _db.Query<ShiftWorker>("SELECT * FROM Engineers INNER JOIN Employees ON Engineers.EmployeeId = Employees.EmployeeId;");
        }

        public Engineer GetById(int id)
        {
            var engineer = _db.Query<Engineer>("SELECT * FROM Engineers WHERE Id = @id", new { id }).FirstOrDefault();
            return engineer;
        }
        public Engineer Add(Engineer entity)
        {
            entity.EngineerId = _db.QueryFirstAsync("SELECT MAX(EngineerId) FROM Engineers").Result + 1;
            _db.Execute("INSERT INTO Engineers (EngineerId, EmployeeId) VALUES (@EngineerId, @EmployeeId)", entity);
            return entity;
        }

        public void Update(Engineer entity, int id)
        {
            _db.ExecuteAsync("UPDATE Engineers SET EngineerId = @EngineerId, FirstShift = @FirstShift, LastShift = @LastShift, ShiftCount = @ShiftCount, EmployeeId = @EmployeeId WHERE EngineerId = @id", entity); 
        }
        public void Delete(Engineer entity)
        {
            _db.Execute("DELETE FROM Engineers WHERE EngineerId = @EngineerId", entity);
        }
        public void Delete(int id)
        {
            _db.Execute("DELETE FROM Engineers WHERE EngineerId = @id", new { id });
        }

        public void Dispose()
        {
            _db.Dispose(); 
        }
    }
}
