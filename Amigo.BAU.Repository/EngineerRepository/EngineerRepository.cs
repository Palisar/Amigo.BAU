using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amigo.BAU.Repository.Models;
using Dapper;
using System.Data.SqlClient;

namespace Amigo.BAU.Repository.EngineerRepository
{
    public class EngineerRepository : IEngineerRepository
    {
        private IDbConnection _db;

        private string connectionString =
            "Data Source=DESKTOP-PALISAR\\SQLEXPRESS;Initial Catalog=AmigoDb;Trusted_Connection=True;";
        public EngineerRepository()
        {
            _db = new SqlConnection(connectionString);
        }

        public IEnumerable<Engineer> GetAll()
        {
            return _db.Query<Engineer>("SELECT * FROM Engineer");
        }
        public Engineer GetById(int id)
        {
            var engineer = _db.Query<Engineer>("SELECT * FROM Engineer WHERE Id = @id", new { id }).FirstOrDefault();
            return engineer;
        }
        public Engineer Add(Engineer entity)
        {
            _db.Execute("INSERT INTO Engineers (EngineerId, FirstShift, LastShift, ShiftCount, EmployeeId) VALUES (@EngineerId, @FirstShift, @LastShift, @ShiftCount, @EmployeeId)", entity);
            return entity;
        }

        public void Update(Engineer entity, int id)
        {
            _db.Execute("UPDATE Engineer SET EngineerId = @EngineerId, FirstShift = @FirstShift, LastShift = @LastShift, ShiftCount = @ShiftCount, EmployeeId = @EmployeeId WHERE EngineerId = @id", entity);
        }
        public void Delete(Engineer entity)
        {
            _db.Execute("DELETE FROM Engineer WHERE EngineerId = @EngineerId", entity);
        }
        public void Delete(int id)
        {
            _db.Execute("DELETE FROM Engineer WHERE EngineerId = @id", new { id });
        }
    }
}
