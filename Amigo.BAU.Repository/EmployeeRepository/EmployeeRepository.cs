using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amigo.BAU.Repository.Models;
using Dapper;

namespace Amigo.BAU.Repository.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnection _db;

        private readonly string _connectionString =
            "Data Source=DESKTOP-PALISAR\\SQLEXPRESS;Initial Catalog=AmigoDb;Trusted_Connection=True;";
        public EmployeeRepository()
        {
            _db = new SqlConnection(_connectionString);
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
            _db.Execute("INSERT INTO Employees ( Name, Email) VALUES ( @Name, @Email)", entity);
            return entity;
        }

        public void Update(Employee entity, int id)
        {
            _db.Execute("UPDATE Employees SET Name = @Name, Email = @Email WHERE EmployeeId = @id", entity);
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