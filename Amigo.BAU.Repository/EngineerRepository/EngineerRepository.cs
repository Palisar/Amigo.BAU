using Amigo.BAU.Persistance.Models;
using Amigo.BAU.Persistance.QueryModels;
using Dapper;
using System.Data;


namespace Amigo.BAU.Repository.EngineerRepository
{
    public class EngineerRepository : IEngineerRepository
    {
        private IDbConnection _db;
        public EngineerRepository(IDbConnection db)
        {
            _db = db;
        }

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
            _db.Execute("INSERT INTO Engineers (EngineerId, FirstShift, LastShift, ShiftCount, EmployeeId) VALUES (@EngineerId, @FirstShift, @LastShift, @ShiftCount, @EmployeeId)", entity);
            return entity;
        }

        public void Update(Engineer entity, int id)
        {
            _db.Execute("UPDATE Engineers SET EngineerId = @EngineerId, FirstShift = @FirstShift, LastShift = @LastShift, ShiftCount = @ShiftCount, EmployeeId = @EmployeeId WHERE EngineerId = @id", entity);
        }
        public void Delete(Engineer entity)
        {
            _db.Execute("DELETE FROM Engineers WHERE EngineerId = @EngineerId", entity);
        }
        public void Delete(int id)
        {
            _db.Execute("DELETE FROM Engineers WHERE EngineerId = @id", new { id });
        }
    }
}
