using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amigo.BAU.Application.Models;

namespace Amigo.BAU.Repository.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private IDbConnection _db;
        public EmployeeRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<EmployeeModel> GetAll()
        {
            return _db.Query<EmployeeModel>("SELECT * FROM Employees");
        }

        public Employee GetById(int id)
        {
            return _db.Query<Employee>("SELECT * FROM Employees WHERE Id = @id", new { id }).FirstOrDefault();
        }

        public void Add(Employee entity)
        {
            _db.Execute("INSERT INTO Employees (Name, Email, DepartmentId) VALUES (@Name, @Email, @DepartmentId)", entity);
        }

        public void Update(Employee entity)
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
