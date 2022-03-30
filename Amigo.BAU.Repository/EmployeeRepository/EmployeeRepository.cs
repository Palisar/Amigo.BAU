using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amigo.BAU.Repository.Models;
using Dapper;
using System.Data.SQLite;

namespace Amigo.BAU.Repository.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private IDbConnection _db;
        public EmployeeRepository(string connectionString)
        {
            _db = new SQLiteConnection(connectionString);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _db.Query<Employee>("SELECT * FROM Employees");
        }

        public Employee GetById(int id)
        {
            return _db.Query<Employee>("SELECT * FROM Employees WHERE Id = @id", new { id }).FirstOrDefault();
        }

        public void Add(Employee entity)
        {
            _db.Execute("INSERT INTO Employees (FirstName, LastName, Email, DepartmentId) VALUES (@Name, @Email, @DepartmentId)", entity);
        }
        
        public void Update(Employee entity, int id)
        {
            _db.Execute("UPDATE Employees SET Name = @Name, Email = @Email, DepartmentId = @DepartmentId WHERE Id = @Id", entity);
        }

        public void Delete(Employee entity)
        {
            _db.Execute("DELETE FROM Employees WHERE Id = @Id", entity);
        }

        public void Delete(int id)
        {
            _db.Execute("DELETE FROM Employees WHERE Id = @id", new { id });
        }
    }
}
