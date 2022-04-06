using System.Data.SqlClient;
using Amigo.BAU.Persistance.Models;
using Amigo.BAU.Repository.EmployeeRepository;
using FluentAssertions;

namespace Amigo.BAU.Repository.Tests
{
    public class EmployeeRepoTests
    {
        [Fact]
        public void Add_Returns_Employee()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeId = 0,
                Name = "Paul Keating",
                Email = "palisar@hotmail.co.uk"
            };

            var repo = new EmployeeRepository.EmployeeRepository(new SqlConnection("Data Source=DESKTOP-88PT757\\SQLEXPRESS;Initial Catalog=AmigoDb;Trusted_Connection=True;"));
            //Act
            var expected = repo.Add(employee);

            //Assert
            expected.Should().Be(employee);
        }

        [Fact]
        public void GetById_Retuns_EmplyeeModel()
        {

        }
    }
}
