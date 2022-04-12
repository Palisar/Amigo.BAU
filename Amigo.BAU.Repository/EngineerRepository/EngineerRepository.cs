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

        public async Task<IEnumerable<Engineer>> GetAll()
        {
            return await _db.QueryAsync<Engineer>("SELECT * FROM Engineers");
        }

        public async Task<IEnumerable<ShiftWorker>> GetNamedEngineers()
        {
            return await _db.QueryAsync<ShiftWorker>("SELECT * FROM Engineers INNER JOIN Employees ON Engineers.EmployeeId = Employees.EmployeeId;");
        }

        public async Task<Engineer> GetById(int id)
        {
            var engineer = await _db.QuerySingleAsync<Engineer>("SELECT * FROM Engineers WHERE Id = @id", new { id });
            return engineer;
        }
        public async Task<Engineer> Add(Engineer entity)
        {
            entity.EngineerId = await _db.QueryFirstAsync("SELECT MAX(EngineerId) FROM Engineers").Result + 1;
            await _db.ExecuteAsync("INSERT INTO Engineers (EngineerId, EmployeeId) VALUES (@EngineerId, @EmployeeId)", entity);
            return entity;
        }

        public async Task UpdateAll(IEnumerable<Engineer> workers)
        {
            foreach (var shiftWorker in workers)
            {
                await Update(shiftWorker, shiftWorker.EngineerId);
            }
        }
        public async Task Update(Engineer entity, int id)
        {
            var query =
                @"UPDATE Engineers SET EngineerId = @EngineerId, FirstShift = @FirstShift, LastShift = @LastShift, ShiftCount = @ShiftCount, @EmployeeId = EmployeeId WHERE EngineerId = @EngineerId";
            await _db.ExecuteAsync(query, entity);
        }
        public async Task Delete(Engineer entity)
        {
            await _db.ExecuteAsync("DELETE FROM Engineers WHERE EngineerId = @EngineerId", entity);
        }
        public async Task Delete(int id)
        {
            await _db.ExecuteAsync("DELETE FROM Engineers WHERE EngineerId = @id", new { id });
        }
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
