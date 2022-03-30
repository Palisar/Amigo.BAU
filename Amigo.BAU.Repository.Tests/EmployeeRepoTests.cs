using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Amigo.BAU.Repository.Models;
using FluentAssertions;

namespace Amigo.BAU.Repository.Tests
{
    public class EmployeeRepoTests
    {
        [Fact]
        public void GetByAll_Returns_IEnumOfEmployee()
        {
            // Arrange
            var moq = new Mock<IEmployeeRepository>();
            moq.Setup(m => m.GetAll()).Returns(new List<Employee>
            {
                new Employee {EmployeeId = 1, Name = "John"},
                new Employee {EmployeeId = 2, Name = "Mary"}
            });

            var repo = moq.Object;
            //Act
            var result = repo.GetAll();
            //Assert
            result.Should().NotBeEmpty();
            result.Should(). BeEquivalentTo(new List<Employee>
            {
               new Employee() {
                   EmployeeId = 1,
                   Name = "John"
                },
               new Employee()
               {
                   EmployeeId = 2,
                   Name = "Mary",
               }
            });
        }

        [Fact]
        public void GetById_Retuns_EmplyeeModel()
        {
            var moq = new Mock<IEmployeeRepository>();
            moq.Setup(m => m.GetById(1)).Returns(new Employee()
                {
                    EmployeeId = 1,
                    Name = "John",
                });
            var repo = moq.Object;

            var result = repo.GetById(1);

            result.Name.Should().Be("John");
        }
    }
}
