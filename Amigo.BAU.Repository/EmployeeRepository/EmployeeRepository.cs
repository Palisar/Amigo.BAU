using Amigo.BAU.Persistance.Models;
using Dapper;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace Amigo.BAU.Repository.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnection _db;
        public EmployeeRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _db.Query<Employee>("SELECT * FROM Employees");
        }

        public Employee GetById(int id)
        {
            return _db.QueryFirstOrDefault<Employee>("SELECT * FROM Employees WHERE EmployeeId = @id", new { id });
        }

        public Employee Add(Employee entity)
        {
            _db.Execute("INSERT INTO Employees ( EmployeeId, Name, Email) VALUES (@EmployeeId, @Name, @Email)", entity);
            return entity;
        }

        public async Task Update(Employee entity, int id)
        {
            var task =  _db.ExecuteAsync("UPDATE Employees SET Name = @Name, Email = @Email WHERE EmployeeId = @id", entity);
            
        }

        public void Delete(Employee entity)
        {
            _db.Execute("DELETE FROM Employees WHERE EmployeeId = @EmployeeId", entity);
        }

        public void Delete(int id)
        {
            _db.Execute("DELETE FROM Employees WHERE EmployeeId = @id", new { id });
        }

    }
}